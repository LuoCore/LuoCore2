using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.WebSite.Request
{
    public class RequestMuneQueryPageVm : RequestMuneQueryVm
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
