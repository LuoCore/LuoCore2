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
        public Task<ViewModels.ResultVm> DeleteBlogLabels(string[] ids, string userName, string userInfo);

        public Task<List<ViewModels.Layui.SelectBoxVm>> QueryBlogLabelsSelectBox(ViewModels.Blog.Request.RequestQueryBlogLabelsSelectBox req);


        public Task<ViewModels.ResultVm> CreateBlogArticle(ViewModels.Blog.Request.RequestCreateBlogArticleVm req);
        public Task<ViewModels.ResultVm> UpdateBlogArticle(ViewModels.Blog.Request.RequestUpdateBlogArticleVm req);
        public Task<ViewModels.ResultVm> DeleteBlogArticle(ViewModels.Blog.Request.RequestDeleteBlogArticleVm req);
    }
}
