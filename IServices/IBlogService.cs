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
    }
}
