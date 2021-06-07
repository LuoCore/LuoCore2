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


        public Task<ViewModels.Layui.TableVm> GetPermissionTable(RequestPermissionVm req)
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();

            var result = _REPOSITORY3.ReadPermissionTableData(new DataTransferModels.BasePermission.Request.RequestPermissionDto(req.PermissionId, req.PermissionName, req.PermissionType, req.PermissionAction, req.PermissionParentId, req.StartTime, req.EndTime, req.CreateName, req.IsValid));
            if (!result.Status || Equals(null, result.Data))
            {
                res.code = -1;
                res.msg = "无数据！";
                return Task.FromResult(res);
            }
            List<ViewModels.SystemBasis.Response.ResponsePermissionVm> resData = new List<ViewModels.SystemBasis.Response.ResponsePermissionVm>();
            foreach (var item in result.Data.TableData)
            {
                resData.Add(new ViewModels.SystemBasis.Response.ResponsePermissionVm()
                {
                    PermissionId=item.PermissionId,
                    PermissionName=item.PermissionName,
                    PermissionAction=item.PermissionAction,
                    PermissionParentId=item.PermissionParentId,
                    PermissionParentName=item.PermissionParentName,
                    PermissionType=item.PermissionType,
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


    }
}
