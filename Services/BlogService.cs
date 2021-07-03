using IRepository;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;

namespace Services
{
    public class BlogService : SqlSugarRepository<ISystemLogsRepository, IBlogArticleRepository,IBlogLabelsRepository>, IBlogService
    {
        public BlogService(ISqlSugarFactory factory, ISystemLogsRepository repository, IBlogArticleRepository repository2, IBlogLabelsRepository repository3) : base(factory, repository, repository2, repository3)
        {
        }

        public Task<ViewModels.Layui.TableVm> QueryBlogArticlePage(ViewModels.Blog.Request.RequestQueryArticleVm req) 
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
           var result= _REPOSITORY2.ReadArticlePageList(new DataTransferModels.BlogArticle.Request.RequestQueryBlogArticleDto(req.UserId, req.ArticleTitle, req.IsValid, req.StartTime, req.EndTime, req.PageIndex, req.PageSize));
            res.code = -1;
            if (result.Status)
            {
                res.code = 0;
                res.count = result.Data.PageCount;
                res.data = result.Data.PageData;
            }
            res.msg = result.Messages;
            return Task.FromResult(res);
        }

        public Task<ViewModels.Layui.TableVm> QueryBlogLabelsPage(ViewModels.Blog.Request.RequestQueryBlogLabelPageVm req)
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
            var result = _REPOSITORY3.ReadLabelsPageList(new DataTransferModels.BlogLabels.Request.RequestQueryBlogLabelPageDto(req.LabelId,req.LabelName,req.IsValid,req.StartTime,req.EndTime,req.PageIndex,req.PageSize));
            res.code = -1;
            if (result.Status)
            {
                res.code = 0;
                res.count = result.Data.PageCount;
                res.data = result.Data.LabelDataList;
            }
            res.msg = result.Messages;
            return Task.FromResult(res);
        }

        public Task<ViewModels.ResultVm> CreateBlogLabels(ViewModels.Blog.Request.RequestCreateBlogLabelVm req)
        {
            ViewModels.ResultVm res = new ViewModels.ResultVm();
            var result = _REPOSITORY3.CreateLabels(new DataTransferModels.BlogLabels.Request.RequestCreateBlogLabelDto(req.LabelId,req.LabelName,req.LabelDescribe,req.IsValid,_REPOSITORY.GetNowDateTime(),req.ActionUserName,req.ActionUserInfo));
            res.Messages = result.Messages;
            res.Status = result.Status;
            return Task.FromResult(res);
        }
        public Task<ViewModels.ResultVm> UpdateBlogLabels(ViewModels.Blog.Request.RequestUpdateBlogLabelVm req)
        {
            ViewModels.ResultVm res = new ViewModels.ResultVm();
            var result = _REPOSITORY3.UpdateLabels(new DataTransferModels.BlogLabels.Request.RequestUpdateBlogLabelDto(req.LabelId,req.LabelName,req.LabelDescribe,req.IsValid,req.ActionUserName,req.ActionUserInfo));
            res.Messages = result.Messages;
            res.Status = result.Status;
            return Task.FromResult(res);
        }
    }
}
