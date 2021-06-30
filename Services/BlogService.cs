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
    public class BlogService : SqlSugarRepository<ISystemLogsRepository, IBlogArticleRepository>, IBlogService
    {
        public BlogService(ISqlSugarFactory factory, ISystemLogsRepository repository, IBlogArticleRepository repository2) : base(factory, repository, repository2)
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
    }
}
