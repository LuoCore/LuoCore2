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

namespace Services
{
    public class SystemBasisService : SqlSugarRepository<ISystemLogsRepository, IUserRepository, IPermissionRepository>, ISystemBasisService
    {
        public SystemBasisService(ISqlSugarFactory factory, ISystemLogsRepository repository, IUserRepository repository2, IPermissionRepository repository3) : base(factory, repository, repository2, repository3)
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

            foreach (var item in result.Data)
            {
                var resData = new ViewModels.Layui.SelectBoxVm()
                {
                    disabled = !item.IsValid,
                    Name = item.PermissionName,
                    value = item.PermissionId
                };
                var resultChildren = await GetPermissionSelectBoxAsync(item.PermissionId);
                if (result.Status && !Equals(null, result.Data))
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
           _REPOSITORY3.CreatePermission(new DataTransferModels.BasePermission.Request.RequestCreatePermissionDto(Guid.NewGuid(),req.PermissionName,req.PermissionType))
            return Task.FromResult(res);
        }

    }
}
