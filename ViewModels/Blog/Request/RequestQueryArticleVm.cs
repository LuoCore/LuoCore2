using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Blog.Request
{
    public class RequestQueryArticleVm
    {
        public string UserId { get;  set; }
        public string ArticleTitle { get;  set; }
        public bool? IsValid { get;  set; }
        public DateTime? StartTime { get;  set; }
        public DateTime? EndTime { get;  set; }
        public int PageIndex { get;  set; }
        public int PageSize { get;  set; }
    }
}
