using DataTransferModels;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using EntitysModels;
using DataTransferModels.WebSiteImages.Request;

namespace Repository
{
    public class WebSiteImagesRepository : SqlSugarRepository<ISystemLogsRepository>, IWebSiteImagesRepository
    {
        public WebSiteImagesRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
        {
        }

        public ResultListDto<WebSite_Images> ReadWebSiteImagesPage(RequestWebSiteImagesReadPageDto req)
        {
            ResultListDto<WebSite_Images> res = new ResultListDto<WebSite_Images>();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    var sqlExecute = db.Queryable<WebSite_Images>();
                    sqlExecute.WhereIF(req.ImageID > 0, x => x.ImageID == req.ImageID);
                    sqlExecute.WhereIF(req.IsValid != null, x => x.IsValid == req.IsValid);
                    res.Datas = new List<WebSite_Images>();
                    int pagecount = 0;
                    res.Datas = sqlExecute.ToPageList(req.PageIndex, req.PageSize, ref pagecount);
                    res.DatasCount = pagecount;
                    res.Status = true;

                });
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Messages = ex.Message;
            }
            return res;
        }


        public ResultDto CreateWebSiteImages(RequestWebSiteImagesCreateDto req)
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    var nowData = new
                    {
                        req.Favicon16,
                        req.Favicon32,
                        req.MaskIcon,
                        req.LogoBrand,
                        req.LogoBrandAlt,
                        req.IsValid
                    };
                    db.Insertable<WebSite_Images>(nowData).ExecuteCommand();
                    _REPOSITORY.SqlTypeCurd<WebSite_Images>(EnumHelper.CURDEnum.创建).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).NowData(nowData).BuilderSQL(db);
                    res.Status = true;
                });
            }
            catch (Exception ex)
            {
                res.Messages = ex.Message;
                res.Status = false;
            }
            return res;
        }


        public ResultDto UpdateWebSiteImages(RequestWebSiteImagesUpdateDto req)
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                  var oldData=  db.Queryable<WebSite_Images>().Where(x => x.ImageID == req.ImageID).First();
                    var nowData = new
                    {
                        req.Favicon16,
                        req.Favicon32,
                        req.MaskIcon,
                        req.LogoBrand,
                        req.LogoBrandAlt,
                        req.IsValid
                    };
                    db.Updateable<WebSite_Images>(nowData).Where(x=>x.ImageID==req.ImageID).ExecuteCommand();
                    _REPOSITORY.SqlTypeCurd<WebSite_Images>(EnumHelper.CURDEnum.更新).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).NowData(nowData).OldData(oldData).BuilderSQL(db);
                    res.Status = true;
                });
            }
            catch (Exception ex)
            {
                res.Messages = ex.Message;
                res.Status = false;
            }
            return res;
        }

        public ResultDto DeleteWebSiteImages(RequestWebSiteImagesDeleteDto req)
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    var oldData = db.Queryable<WebSite_Images>().Where(x => x.ImageID == req.ImageID).First();
                    var nowData = new
                    {

                        IsValid = false
                    };
                    db.Updateable<WebSite_Images>(nowData).Where(x => x.ImageID == req.ImageID).ExecuteCommand();
                    _REPOSITORY.SqlTypeCurd<WebSite_Images>(EnumHelper.CURDEnum.删除).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).NowData(nowData).OldData(oldData).BuilderSQL(db);
                    res.Status = true;
                });
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
