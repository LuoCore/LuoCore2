using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Blog.Request
{
    public class RequestQueryBlogLabelPageVm
    {
        public string LabelId { get; protected set; }
        public string LabelName { get; protected set; }
        public bool? IsValid { get; protected set; }
        public DateTime? StartTime { get; protected set; }
        public DateTime? EndTime { get; protected set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
