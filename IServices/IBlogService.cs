using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IBlogService
    {
        public Task<ViewModels.Layui.TableVm> QueryBlogArticlePage(ViewModels.Blog.Request.RequestQueryArticleVm req);
        public Task<ViewModels.Layui.TableVm> QueryBlogLabelsPage(ViewModels.Blog.Request.RequestQueryBlogLabelPageVm req);
        public Task<ViewModels.ResultVm> CreateBlogLabels(ViewModels.Blog.Request.RequestCreateBlogLabelVm req);
        public Task<ViewModels.ResultVm> UpdateBlogLabels(ViewModels.Blog.Request.RequestUpdateBlogLabelVm req);
    }
}
