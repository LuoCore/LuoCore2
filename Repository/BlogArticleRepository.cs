using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using DataTransferModels;
using SqlSugar;
using Common;

namespace Repository
{
    public class BlogArticleRepository : SqlSugarRepository<ISystemLogsRepository>, IBlogArticleRepository
    {
        public BlogArticleRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
        {
        }

        public ResultDto<DataTransferModels.BlogArticle.Response.ResponseBlogArticlePageDto> ReadArticlePageList(DataTransferModels.BlogArticle.Request.RequestQueryBlogArticleDto req)
        {
            ResultDto<DataTransferModels.BlogArticle.Response.ResponseBlogArticlePageDto> res = new ResultDto<DataTransferModels.BlogArticle.Response.ResponseBlogArticlePageDto>();
            _FACTORY.GetDbContext((db) =>
            {
                try
                {
                    res.Data = new DataTransferModels.BlogArticle.Response.ResponseBlogArticlePageDto();
                    var sqlExe = db.Queryable<EntitysModels.Blog_Article>()
                    .WhereIF(!string.IsNullOrWhiteSpace(req.UserId), x => x.UserId == req.UserId)
                    .WhereIF(!string.IsNullOrWhiteSpace(req.ArticleTitle), x => x.ArticleTitle == req.ArticleTitle)
                    .WhereIF(!Equals(null, req.IsValid), x => x.IsValid == req.IsValid)
                    .WhereIF(!Equals(null, req.StartTime) && !Equals(null, req.EndTime), x => SqlFunc.Between(x.CreateTime, req.StartTime, req.EndTime));

                    var selectSql = sqlExe.Select(x => new DataTransferModels.BlogArticle.Response.ResponseBlogArticleDto()
                    {
                        ArticleTitle = x.ArticleTitle,
                        ArticleConten = x.ArticleConten,
                        IsValid = x.IsValid,
                        UserId = x.UserId
                    });
                    res.Data.PageData = new List<DataTransferModels.BlogArticle.Response.ResponseBlogArticleDto>();
                    int pageCount = 0;
                    res.Data.PageData = selectSql.ToPageList(req.PageIndex, req.PageSize, ref pageCount);
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

        public ResultDto CreateArticle(DataTransferModels.BlogArticle.Request.RequestCreateBlogArticleDto req)
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    var data = new
                    {
                        ArticleId = Guid.NewGuid(),
                        UserId = req.UserId,
                        ArticleTitle = req.ArticleTitle,
                        ArticleConten = req.ArticleConten,
                        CreateName = req.ActionUserName,
                        IsValid = req.IsValid,
                    };
                    db.Insertable<EntitysModels.Blog_Article>(data).ExecuteCommandIdentityIntoEntity();
                    _REPOSITORY.LogSave<EntitysModels.Blog_Article>(db, EnumHelper.CURDEnum.创建, data.ToJson(), null, req.ActionUserName, req.ActionUserInfo).ExecuteCommand();
                });
                res.Status = true;
            }
            catch (Exception ex)
            {
                res.Messages = ex.Message;
                res.Status = false;
            }
            return res;

        }

        public ResultDto UpdateArticleById(DataTransferModels.BlogArticle.Request.RequestUpdateBlogArticleDto req)
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    var udpateData = db.Queryable<EntitysModels.Blog_Article>().Where(x => x.ArticleId.Equals(req.ArticleId)).First();
                    var data = new
                    {
                        ArticleTitle = req.ArticleTitle,
                        ArticleConten = req.ArticleConten,
                        IsValid = req.IsValid,
                    };
                    db.Updateable<EntitysModels.Blog_Article>(data).Where(x => x.ArticleId.Equals(req.ArticleId)).ExecuteCommandHasChange();
                    _REPOSITORY.LogSave<EntitysModels.Blog_Article>(db, EnumHelper.CURDEnum.更新, data.ToJson(), udpateData.ToJson(), req.ActionUserName, req.ActionUserInfo).ExecuteCommand();
                });
                res.Status = true;
            }
            catch (Exception ex)
            {

                res.Messages = ex.Message;
                res.Status = false;
            }
            return res;
        }
        public ResultDto DeleteArticleById(DataTransferModels.BlogArticle.Request.RequestDeleteBlogArticleDto req)
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    var udpateData = db.Queryable<EntitysModels.Blog_Article>().Where(x => x.ArticleId.Equals(req.ArticleId)).First();
                    var data = new
                    {
                        IsValid = false,
                    };
                    db.Updateable<EntitysModels.Blog_Article>(data).Where(x => x.ArticleId.Equals(req.ArticleId)).ExecuteCommandHasChange();
                    _REPOSITORY.LogSave<EntitysModels.Blog_Article>(db, EnumHelper.CURDEnum.删除, data.ToJson(), udpateData.ToJson(), req.ActionUserName, req.ActionUserInfo).ExecuteCommand();
                });
                res.Status = true;
            }
            catch (Exception ex)
            {

                res.Messages = ex.Message;
                res.Status = false;
            }
            return res;
        }
    }
}
