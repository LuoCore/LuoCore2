using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.SystemBasis.Request;

namespace IServices
{
    public interface ISystemBasisService
    {
        public  Task<ResultVm<List<ViewModels.Layui.SelectBoxVm>>> GetPermissionSelectBoxAsync(string parentId);
        public Task<ViewModels.Layui.TableVm> GetPermissionTable(RequestPermissionVm req);
    }
}
