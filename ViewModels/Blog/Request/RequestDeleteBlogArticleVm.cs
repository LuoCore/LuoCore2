using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Blog.Request
{
    public class RequestDeleteBlogArticleVm:RequestBaseVm
    {
        public string[] ArticleIds { get;  set; }
    }
}
