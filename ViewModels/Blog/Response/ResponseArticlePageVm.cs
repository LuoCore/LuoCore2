using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Blog.Response
{
    public class ResponseArticlePageVm
    {
        public List<ResponseArticleVm> PageData { get; set; }
        public int PageCount { get; set; }
    }
}
