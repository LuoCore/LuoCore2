using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Blog.Request
{
    public class RequestUpdateBlogArticleVm : RequestBaseVm
    {
        public string ArticleId { get;  set; }
        public string ArticleTitle { get;  set; }
        public string ArticleConten { get;  set; }
        public bool IsValid { get;  set; }

        public string LabelsIds { get; set; }
    }
}
