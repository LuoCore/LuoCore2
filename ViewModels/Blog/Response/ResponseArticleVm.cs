using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Blog.Response
{
    public class ResponseArticleVm
    {
        public string UserId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleConten { get; set; }
        public bool IsValid { get; set; }
    }
}
