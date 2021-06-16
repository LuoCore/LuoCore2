using IRepository;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using ViewModels;
using ViewModels.SystemBasis.Request;
using Common;
using EnumHelper;
using DataTransferModels.BsaeRole.Request;

namespace Services
{
    public class SystemBasisService : SqlSugarRepository<ISystemLogsRepository, IUserRepository, IPermissionRepository,IRoleRepository>, ISystemBasisService
    {
        public SystemBasisService(ISqlSugarFactory factory, ISystemLogsRepository repository, IUserRepository repository2, IPermissionRepository repository3,IRoleRepository repository4) : base(factory, repository, repository2, repository3, repository4)
        {
        }

        public async Task<ResultVm<List<ViewModels.Layui.SelectBoxVm>>> GetPermissionSelectBoxAsync(string parentId)
        {
            ResultVm<List<ViewModels.Layui.SelectBoxVm>> resSelects = new ResultVm<List<ViewModels.Layui.SelectBoxVm>>();

            var result = _REPOSITORY3.ReadPermissionByParentId(parentId);
            if (!result.Status || Equals(null, result.Data))
            {
                return resSelects;
            }
            resSelects.Data = new List<ViewModels.Layui.SelectBoxVm>();
            foreach (var item in result.Data)
            {
                var resData = new ViewModels.Layui.SelectBoxVm()
                {
                    disabled = !item.IsValid,
                    Name = item.PermissionName,
                    value = item.PermissionId
                };
                var resultChildren = await GetPermissionSelectBoxAsync(item.PermissionId);
                if (resultChildren.Status && !Equals(null, resultChildren.Data))
                {
                    resData.children = resultChildren.Data;
                }
               
                resSelects.Data.Add(resData);
            }
            resSelects.Status = true;
            return resSelects;
        }

        public Task<ViewModels.Layui.TableVm> GetPermissionTable(RequestGetPermissionVm req)
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();

          
            var result = _REPOSITORY3.ReadPermissionTableData(new DataTransferModels.BasePermission.Request.RequestWherePermissionDto(req.PermissionId, req.PermissionName, req.PermissionType.EnumToInt(), req.PermissionAction, req.PermissionParentId, req.StartTime, req.EndTime, req.CreateName, req.IsValid));
            if (!result.Status || Equals(null, result.Data))
            {
                res.code = -1;
                res.msg = "无数据！";
                return Task.FromResult(res);
            }
            List<ViewModels.SystemBasis.Response.ResponsePermissionTableVm> resData = new List<ViewModels.SystemBasis.Response.ResponsePermissionTableVm>();
            foreach (var item in result.Data.TableData)
            {
                string ParentName = item.PermissionParentName;
                if (string.IsNullOrWhiteSpace(item.PermissionParentName)) 
                {
                    ParentName = "顶级";
                }
                var permissionTypeEnum = item.PermissionType.ObjToInt().IntToEnum<PermissionTypeEnum>();
                resData.Add(new ViewModels.SystemBasis.Response.ResponsePermissionTableVm()
                {
                    PermissionId=item.PermissionId,
                    PermissionName=item.PermissionName,
                    PermissionAction=item.PermissionAction,
                    PermissionParentId= item.PermissionParentId,
                    PermissionParentName = ParentName,
                    PermissionType=item.PermissionType.ObjToInt(),
                    PermissionTypeName= permissionTypeEnum.EnumToString(),
                    CreateName=item.CreateName,
                    CreateTime=item.CreateTime,
                    IsValid=item.IsValid
                });
            }
            res.code = 0;
            res.data = resData;
            res.count = resData.Count;
             return Task.FromResult(res);
        }

        public Task<ViewModels.ResultVm> AddPermission(RequestAddPermissionVm req)
        {
            ResultVm res = new ResultVm();
            var result= _REPOSITORY3.CreatePermission(new DataTransferModels.BasePermission.Request.RequestCreatePermissionDto(req.UserName,req.UserInfo,Guid.NewGuid(), req.PermissionName, req.PermissionType.EnumToInt(), req.PermissionAction, req.PermissionParentId, req.IsValid));
            if (Equals(null, result))
            {
                res.Messages = "失败！未知异常。";
                res.Status = false;
                return Task.FromResult(res);
            }
            if (!result.Status)
            {
                res.Status = true;
                res.Messages = result.Messages;
                return Task.FromResult(res);
            }
            res.Status = true;
            res.Messages = "成功！";
            return Task.FromResult(res);

        }

        public Task<ViewModels.ResultVm> UpdatePermissionById(RequestUpdatePermissionVm req)
        {
            ResultVm res = new ResultVm();
            var result = _REPOSITORY3.UpdatePermissionById(new DataTransferModels.BasePermission.Request.RequestUpdatePermissionByIdDto(req.UserName,req.UserInfo,req.PermissionName, req.PermissionType, req.PermissionAction,req.PermissionParentId,req.IsValid),req.PermissionId);

            if (Equals(null, result))
            {
                res.Messages = "失败！未知异常。";
                res.Status = false;
                return Task.FromResult(res);
            }
            if (!result.Status)
            {
                res.Status = true;
                res.Messages = result.Messages;
                return Task.FromResult(res);
            }
            res.Status = true;
            res.Messages = "成功！";
            return Task.FromResult(res);
        }

        public Task<ViewModels.ResultVm> DeletePermissionByIds(RequestDeletePermissionVm req)
        {
            ResultVm res = new ResultVm();
            var result = _REPOSITORY3.DeletePermissionByIds(new DataTransferModels.BasePermission.Request.RequestDeletePermissionByIdsDto(req.UserName, req.UserInfo, req.PermissionIds));

            if (Equals(null, result))
            {
                res.Messages = "失败！未知异常。";
                res.Status = false;
                return Task.FromResult(res);
            }
            if (!result.Status)
            {
                res.Status = true;
                res.Messages = result.Messages;
                return Task.FromResult(res);
            }
            res.Status = true;
            res.Messages = "成功！";
            return Task.FromResult(res);
        }

        public Task<ViewModels.Layui.TableVm> GetRoleTable(RequestGetRoleVm req) 
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
            var result = _REPOSITORY4.ReadRolePageList(new RequestQueryRoleDto(req.RoleId,req.RoleName,req.IsValid,req.StartTime,req.EndTime,req.PageIndex,req.PageSize));
            if (!result.Status || Equals(null, result.Data)|| result.Data.PageList.Count<1)
            {
                res.code = -1;
                res.msg = "无数据！";
                return Task.FromResult(res);
            }
            res.code = 0;
            res.data = result.Data.PageList;
            res.count = result.Data.PageCount;
            return Task.FromResult(res);
        }
    }
}
