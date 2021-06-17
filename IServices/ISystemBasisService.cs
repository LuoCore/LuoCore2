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
        public  Task<ResultVm<List<ViewModels.Layui.TreeVm>>> GetPermissionTreeBoxAsync(string parentId);
        public Task<ViewModels.Layui.TableVm> GetPermissionTable(RequestGetPermissionVm req);
        public Task<ViewModels.ResultVm> AddPermission(RequestAddPermissionVm req);
        public Task<ViewModels.ResultVm> UpdatePermissionById(RequestUpdatePermissionVm req);
        public Task<ViewModels.ResultVm> DeletePermissionByIds(RequestDeletePermissionVm req);
        public Task<ViewModels.Layui.TableVm> GetRoleTable(RequestGetRoleVm req);
        public Task<ResultVm> AddRole(RequestAddRoleVm req);
        public Task<ResultVm> AddRolePermission(RequestAddRolePermissionVm req);
    }
}
