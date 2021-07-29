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
        public Task<ViewModels.Layui.TableVm> MenuQueryPage(RequestMenuQueryPageVm req);
        public Task<ResultListVm<WebSite_Menu>> MenuQueryList(RequestMenuQueryVm req);
        public  Task<ResultVm<List<ViewModels.Layui.SelectBoxVm>>> MenuQuerySelectBoxAsync(int parentId);
        public Task<ViewModels.Layui.TableVm> MenuQueryTreeTable(RequestMenuQueryVm req);
        public Task<ResultVm> MenuCreate(RequestMenuCreateVm req);
        public Task<ResultVm> MenuUpdate(RequestMenuUpdateVm req);
        public Task<ResultVm> MenuDelete(RequestMenuDeleteVm req);
    }
}
