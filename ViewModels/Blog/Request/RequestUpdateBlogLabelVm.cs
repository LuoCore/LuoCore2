using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Blog.Request
{
    public class RequestUpdateBlogLabelVm:RequestBaseVm
    {
        public string LabelId { get; set; }
        public string LabelName { get; set; }
        public string LabelDescribe { get; set; }
        public bool IsValid { get; set; }
    }
}
