using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.WebSite.Request;

namespace IServices
{
    public interface IWebSiteService
    {
        public ResultListVm<WebSite_Menu> MenuQueryPage(RequestMuneQueryPageVm req);
        public ResultListVm<WebSite_Menu> MenuQueryList(RequestMuneQueryVm req);
        public ResultVm MenuCreate(RequestMenuCreateVm req);
        public ResultVm MenuUpdate(RequestMenuUpdateVm req);
        public ResultVm MenuDelete(RequestMenuDeleteVm req);
    }
}
