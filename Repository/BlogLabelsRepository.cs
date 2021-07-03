using DataTransferModels;
using DataTransferModels.BlogLabels.Request;
using DataTransferModels.BlogLabels.Response;
using IRepository;
using SqlSugar;
using System;
using System.Collections.Generic;
using EntitysModels;
using Utility.Factory;
using Utility.Repository;


namespace Repository
{
    public class BlogLabelsRepository : SqlSugarRepository<ISystemLogsRepository>, IBlogLabelsRepository
    {
        public BlogLabelsRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
        {
        }
        public ResultDto<ResponseBlogLabelListDto> ReadLabelsList(RequestQueryBlogLabelDto req)
        {
            ResultDto<ResponseBlogLabelListDto> res = new ResultDto<ResponseBlogLabelListDto>();
            _FACTORY.GetDbContext((db) =>
            {
                try
                {
                    res.Data = new ResponseBlogLabelListDto();

                    var sqlExe = db.Queryable<EntitysModels.Blog_Labels>()
                      .WhereIF(!string.IsNullOrWhiteSpace(req.LabelId), x => x.LabelId == req.LabelId)
                      .WhereIF(!string.IsNullOrWhiteSpace(req.LabelName), x => x.LabelName == req.LabelName)
                      .WhereIF(!Equals(null, req.IsValid), x => x.IsValid == req.IsValid)
                      .WhereIF(!Equals(null, req.StartTime) && !Equals(null, req.EndTime), x => SqlFunc.Between(x.CreateTime, req.StartTime, req.EndTime));

                    res.Data.LabelDataList = new List<ResponseBlogLabelDto>();
                    res.Data.LabelDataList = sqlExe.Select(x => new ResponseBlogLabelDto()
                    {
                        LabelId = x.LabelId,
                        LabelName = x.LabelName,
                        LabelDescribe = x.LabelDescribe,
                        IsValid = x.IsValid
                    }).ToList();
                    res.Status = true;
                }
                catch (Exception ex)
                {
                    res.Messages = ex.Message;
                    res.Status = false;
                }

            });
            return res;
        }

        public ResultDto<ResponseBlogLabelPageListDto> ReadLabelsPageList(RequestQueryBlogLabelPageDto req)
        {
            ResultDto<ResponseBlogLabelPageListDto> res = new ResultDto<ResponseBlogLabelPageListDto>();
            _FACTORY.GetDbContext((db) =>
            {
                try
                {
                    res.Data = new ResponseBlogLabelPageListDto();

                    var sqlExe = db.Queryable<EntitysModels.Blog_Labels>()
                      .WhereIF(!string.IsNullOrWhiteSpace(req.LabelId), x => x.LabelId == req.LabelId)
                      .WhereIF(!string.IsNullOrWhiteSpace(req.LabelName), x => x.LabelName == req.LabelName)
                      .WhereIF(!Equals(null, req.IsValid), x => x.IsValid == req.IsValid)
                      .WhereIF(!Equals(null, req.StartTime) && !Equals(null, req.EndTime), x => SqlFunc.Between(x.CreateTime, req.StartTime, req.EndTime));


                    res.Data.LabelDataList = new List<ResponseBlogLabelDto>();
                    int pageCount = 0;
                    res.Data.LabelDataList = sqlExe.Select(x => new ResponseBlogLabelDto()
                    {
                        LabelId = x.LabelId,
                        LabelName = x.LabelName,
                        LabelDescribe = x.LabelDescribe,
                        IsValid = x.IsValid
                    }).ToPageList(req.PageIndex, req.PageSize, ref pageCount);
                    res.Data.PageCount = pageCount;
                    res.Status = true;
                }
                catch (Exception ex)
                {
                    res.Messages = ex.Message;
                    res.Status = false;
                }

            });
            return res;
        }

        public ResultDto CreateLabels(RequestCreateBlogLabelDto req)
        {
            ResultDto res = new ResultDto();
            _FACTORY.GetDbContextTran((db) =>
            {
                try
                {
                    var insetData = new
                    {
                        LabelId = req.LabelId,
                        LabelName = req.LabelName,
                        LabelDescribe = req.LabelDescribe,
                        IsValid = req.IsValid,
                        CreateName = req.ActionUserName,
                        CreateTime = db.GetDate()

                    };
                    db.Insertable<Blog_Labels>(insetData).ExecuteCommand();
                    _REPOSITORY.SqlTypeCurd<Blog_Labels>(EnumHelper.CURDEnum.创建)
                    .NowData(insetData)
                    .OperationUserInfo(req.ActionUserName, req.ActionUserInfo)
                    .BuilderSQL(db);
                   
                }
                catch (Exception ex)
                {
                    res.Messages = ex.Message;
                    res.Status = false;
                }

            });
            return res;
        }


        public ResultDto UpdateLabels(RequestUpdateBlogLabelDto req)
        {
            ResultDto res = new ResultDto();
            _FACTORY.GetDbContextTran((db) =>
            {
                try
                {
                    var oldData= db.Queryable<Blog_Labels>().Where(x=>x.LabelId==req.LabelId).First();
                    var UpdateData = new
                    {
                        LabelName = req.LabelName,
                        LabelDescribe = req.LabelDescribe,
                        IsValid = req.IsValid
                    };
                    db.Updateable<Blog_Labels>(UpdateData).Where(x=>x.LabelId==req.LabelId).ExecuteCommand();
                    _REPOSITORY.SqlTypeCurd<Blog_Labels>(EnumHelper.CURDEnum.更新)
                    .NowData(UpdateData)
                    .OldData(oldData)
                    .OperationUserInfo(req.ActionUserName, req.ActionUserInfo)
                    .BuilderSQL(db);

                }
                catch (Exception ex)
                {
                    res.Messages = ex.Message;
                    res.Status = false;
                }

            });
            return res;
        }

        public ResultDto DeleteLabels(RequestDeleteBlogLabelDto req)
        {
            ResultDto res = new ResultDto();
            _FACTORY.GetDbContextTran((db) =>
            {
                try
                {
                    var oldData = db.Queryable<Blog_Labels>().Where(x => x.LabelId == req.LabelId).First();
                    var UpdateData = new
                    {
                        IsValid = false
                    };
                    db.Updateable<Blog_Labels>(UpdateData).Where(x => x.LabelId == req.LabelId).ExecuteCommand();
                    _REPOSITORY.SqlTypeCurd<Blog_Labels>(EnumHelper.CURDEnum.删除)
                    .NowData(UpdateData)
                    .OldData(oldData)
                    .OperationUserInfo(req.ActionUserName, req.ActionUserInfo)
                    .BuilderSQL(db);

                }
                catch (Exception ex)
                {
                    res.Messages = ex.Message;
                    res.Status = false;
                }

            });
            return res;
        }

    }
}
