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
using EntitysModels;

namespace Services
{
    public class SystemBasisService : SqlSugarRepository<ISystemLogsRepository, IUserRepository, IPermissionRepository, IRoleRepository, IRolePermissionRepository, IUserRoleRepository>, ISystemBasisService
    {
        public SystemBasisService(ISqlSugarFactory factory, ISystemLogsRepository repository, IUserRepository repository2, IPermissionRepository repository3, IRoleRepository repository4, IRolePermissionRepository repository5, IUserRoleRepository repository6) : base(factory, repository, repository2, repository3, repository4, repository5, repository6)
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


        public Task<ResultVm<List<ViewModels.Layui.SelectBoxVm>>> GetRoleSelectBox(string userId)
        {
            ResultVm<List<ViewModels.Layui.SelectBoxVm>> resSelects = new ResultVm<List<ViewModels.Layui.SelectBoxVm>>();

            var result = _REPOSITORY4.ReadValidRoleList();
            if (Equals(null, result))
            {
                resSelects.Status = false;
                resSelects.Messages = "无数据";
                return Task.FromResult(resSelects);
            }

            var userRoleResult = _REPOSITORY6.ReadUserRoleByUserId(userId);
            resSelects.Data = new List<ViewModels.Layui.SelectBoxVm>();
            foreach (var item in result)
            {
                var resData = new ViewModels.Layui.SelectBoxVm()
                {
                    disabled = !item.IsValid,
                    Name = item.RoleName,
                    value = item.RoleId
                };
                if (userRoleResult.Status && !Equals(null, userRoleResult.Data))
                {
                    if (userRoleResult.Data.Where(x => x.RoleId.Equals(item.RoleId)).Any())
                    {
                        resData.selected = true;
                    }
                }
                resSelects.Data.Add(resData);
            }

            resSelects.Status = true;
            return Task.FromResult(resSelects);
        }


        /// <summary>
        /// 内部构造树形菜单递归查询
        /// </summary>
        /// <param name="permissionId"></param>
        /// <param name="roleList"></param>
        /// <returns></returns>
        private async Task<ResultVm<List<ViewModels.Layui.TreeVm>>> GetPermissionTreeBoxAsync(string permissionId, List<Base_RolePermission> roleList)
        {
            ResultVm<List<ViewModels.Layui.TreeVm>> resTree = new ResultVm<List<ViewModels.Layui.TreeVm>>();
            var result = _REPOSITORY3.ReadPermissionByParentId(permissionId);
            if (result.Status)
            {
                resTree.Data = new List<ViewModels.Layui.TreeVm>();
               
                foreach (var permission in result.Data)
                {
                    ViewModels.Layui.TreeVm treeData = new ViewModels.Layui.TreeVm();
                    treeData.disabled = !permission.IsValid;
                    treeData.title = permission.PermissionName;
                    treeData.id = permission.PermissionId;
                    if (roleList.Where(x => x.PermissionId == treeData.id).Any())
                    {
                        treeData.@checked = true;
                    }
                    var result2 = await GetPermissionTreeBoxAsync(treeData.id, roleList);
                    if (result2.Status&& result2.Data.Count>0)
                    {
                        treeData.@checked = false;
                        treeData.spread = true;
                        treeData.children = result2.Data;
                    }

                    resTree.Data.Add(treeData);
                    resTree.Status = true;
                }
            }
            return resTree;
        }


        public async Task<ResultVm<List<ViewModels.Layui.TreeVm>>> GetPermissionTreeBoxByRoleIdAsync(string permissionId,string roleId)
        {
            ResultVm<List<ViewModels.Layui.TreeVm>> resTree = new ResultVm<List<ViewModels.Layui.TreeVm>>();
            var resultRole = _REPOSITORY5.ReadRolePermissionByRoleId(roleId);
            var result = _REPOSITORY3.ReadPermissionByParentId(permissionId);
            if (result.Status)
            {
                resTree.Data = new List<ViewModels.Layui.TreeVm>();

                foreach (var permission in result.Data)
                {
                    ViewModels.Layui.TreeVm treeData = new ViewModels.Layui.TreeVm();
                    treeData.disabled = !permission.IsValid;
                    treeData.title = permission.PermissionName;
                    treeData.id = permission.PermissionId;
                    if (resultRole.Where(x => x.PermissionId == treeData.id).Any()) 
                    {
                        treeData.@checked = true;
                    }
                    var result2 = await GetPermissionTreeBoxAsync(treeData.id, resultRole);
                    if (result2.Status && result2.Data.Count > 0)
                    {
                        treeData.@checked = false;
                        treeData.spread = true;
                        treeData.children = result2.Data;
                    }
                    resTree.Data.Add(treeData);
                    resTree.Status = true;
                }
            }
            return resTree;
        }




        public  Task<ResultVm<List<EntitysModels.Base_RolePermission>>> GetRolePermissionByRoleIdAsync(string roleId)
        {
            ResultVm<List<EntitysModels.Base_RolePermission>> res = new ResultVm<List<EntitysModels.Base_RolePermission>>();
            var result = _REPOSITORY5.ReadRolePermissionByRoleId(roleId);
            if (!Equals(null, result) && result.Count > 0) 
            {
                res.Data = result;
                res.Status = true;
            }
            return Task.FromResult(res);
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
                    PermissionId = item.PermissionId,
                    PermissionName = item.PermissionName,
                    PermissionAction = item.PermissionAction,
                    PermissionParentId = item.PermissionParentId,
                    PermissionParentName = ParentName,
                    PermissionType = item.PermissionType.ObjToInt(),
                    PermissionTypeName = permissionTypeEnum.EnumToString(),
                    CreateName = item.CreateName,
                    CreateTime = item.CreateTime,
                    IsValid = item.IsValid
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
            var result = _REPOSITORY3.CreatePermission(new DataTransferModels.BasePermission.Request.RequestCreatePermissionDto(req.ActionUserName, req.ActionUserInfo, Guid.NewGuid(), req.PermissionName, req.PermissionType.EnumToInt(), req.PermissionAction, req.PermissionParentId, req.IsValid));
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
            var result = _REPOSITORY3.UpdatePermissionById(new DataTransferModels.BasePermission.Request.RequestUpdatePermissionByIdDto(req.ActionUserName, req.ActionUserInfo, req.PermissionName, req.PermissionType, req.PermissionAction, req.PermissionParentId, req.IsValid), req.PermissionId);

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
            var result = _REPOSITORY3.DeletePermissionByIds(new DataTransferModels.BasePermission.Request.RequestDeletePermissionByIdsDto(req.ActionUserName, req.ActionUserInfo, req.PermissionIds));

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
            var result = _REPOSITORY4.ReadRolePageList(new RequestQueryRoleDto(req.RoleId, req.RoleName, req.IsValid, req.StartTime, req.EndTime, req.PageIndex, req.PageSize));
            if (!result.Status || Equals(null, result.Data) || result.Data.PageList.Count < 1)
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

        public Task<ResultVm> AddRole(RequestAddRoleVm req)
        {
            ResultVm res = new ResultVm();
            Guid gId = Guid.NewGuid();
            var result = _REPOSITORY4.CreateRole(new RequestCreateRoleDto(gId, req.RoleName, req.RoleDescription, req.IsValid, _REPOSITORY.GetNowDateTime(), req.ActionUserName, req.ActionUserInfo));

            if (result.Status)
            {
                res.Status = true;
                res.Messages = "添加成功！";

            }
            else
            {
                res.Status = false;
                res.Messages = "添加失败！" + result.Messages;
            }

            return Task.FromResult(res);
        }
        public Task<ResultVm> UpdateRoleById(RequestUpdateRoleVm req)
        {
            ResultVm res = new ResultVm();
            if (string.IsNullOrWhiteSpace(req.RoleId))
            {
                res.Status = false;
                res.Messages = "角色编号不能为空！";
                return Task.FromResult(res);
            }
            var result = _REPOSITORY4.UpdateRoleById(new RequestUpdateRoleDto(req.RoleId, req.RoleName, req.RoleDescription, req.IsValid,req.ActionUserName, req.ActionUserInfo));

            if (result.Status)
            {
                res.Status = true;
                res.Messages = "修改成功！";

            }
            else
            {
                res.Status = false;
                res.Messages = "修改失败！" + result.Messages;
            }

            return Task.FromResult(res);
        }

        public Task<ResultVm> AddRolePermission(RequestAddRolePermissionVm req)
        {
            ResultVm res = new ResultVm();
            var result = _REPOSITORY5.CreateRolePermission(new DataTransferModels.BaseRolePermission.Request.RequestCreateRolePermissionDto(req.PermissionIds, req.RoleIds, req.ActionUserName, req.ActionUserInfo));

            if (result.Status)
            {
                res.Status = true;
                res.Messages = "添加成功！";

            }
            else
            {
                res.Status = false;
                res.Messages = "添加失败！" + result.Messages;
            }

            return Task.FromResult(res);
        }


        public Task<ViewModels.Layui.TableVm> GetUserTable(RequestGetUserVm req)
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
            var result = _REPOSITORY2.ReadUserPageList(new DataTransferModels.BaseUser.Request.RequestQueryUserDto(req.UserId, req.UserName, req.UserRealName, req.Email, req.Phone, req.Sex, req.IsValid, req.StartTime, req.EndTime, req.PageIndex, req.PageSize));
            if (!result.Status || Equals(null, result.Data))
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

        public Task<ResultVm> UserCreate(RequestAddUserVm req)
        {
            ResultVm res = new ResultVm();
            if (req.Password.Equals(req.PasswordVerify))
            {
                Guid gId = Guid.NewGuid();
                var result = _REPOSITORY2.CreateUser(new DataTransferModels.BaseUser.Request.RequsetRegisteredUserDto(gId, req.UserName, req.UserRealName, req.Password, req.Email, req.Phone, req.Sex, _REPOSITORY.GetNowDateTime(), req.IsValid, req.ActionUserName, req.ActionUserInfo));
                res.Status = result.Status;
                if (res.Status)
                {
                    if (!string.IsNullOrWhiteSpace(req.RoleSelect))
                    {
                        string[] roleIds = req.RoleSelect.Split(new String[] { " ", "    ", ",", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        if (roleIds.Length > 0)
                        {
                            List<string> listRoleId = new List<string>(roleIds);
                            var roleResult = _REPOSITORY6.CreateUserRole(new DataTransferModels.BaseUserRole.Request.RequestCreateUserRoleDto(gId.ToString(), listRoleId, req.ActionUserName, req.ActionUserInfo));
                            if (!roleResult.Status)
                            {
                                res.Messages += "角色添加失败！" + roleResult.Messages;
                            }
                        }
                    }
                }
                else
                {
                    res.Status = result.Status;
                    res.Messages = result.Messages;
                }


            }
            else
            {
                res.Status = false;
                res.Messages = "两次密码不一致，请确认";
            }

            return Task.FromResult(res);
        }


        public Task<ResultVm> UserUpdateById(RequestUpdateUserVm req)
        {
            ResultVm res = new ResultVm();

            var userInfoResult = _REPOSITORY2.ReadUserById(req.UserId);
            if (!userInfoResult.Status)
            {
                res.Status = false;
                res.Messages = "用户不存在无法修改，请确认";
                return Task.FromResult(res);
            }
            var userInfo = userInfoResult.Data;
            if (!string.IsNullOrWhiteSpace(req.PasswordVerify))
            {
                if (string.IsNullOrWhiteSpace(req.Password))
                {
                    res.Status = false;
                    res.Messages = "请输入原密码！";
                    return Task.FromResult(res);
                }
                if (!req.Password.Equals(userInfo.Password))
                {
                    res.Status = false;
                    res.Messages = "用户原密码错误，请确认";
                    return Task.FromResult(res);
                }
            }
            var result = _REPOSITORY2.UpdateUserById(new DataTransferModels.BaseUser.Request.RequestUpdateUserDto(userInfo.UserId, req.UserName, req.UserRealName, req.PasswordVerify, req.Email, req.Phone, req.Sex, req.IsValid, req.ActionUserName, req.ActionUserInfo));

            res.Status = result.Status;
            if (res.Status)
            {
                if (!string.IsNullOrWhiteSpace(req.RoleSelect))
                {
                    string[] roleIds = req.RoleSelect.Split(new String[] { " ", "    ", ",", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    if (roleIds.Length > 0)
                    {
                        List<string> listRoleId = new List<string>(roleIds);
                        var roleResult = _REPOSITORY6.CreateUserRole(new DataTransferModels.BaseUserRole.Request.RequestCreateUserRoleDto(userInfo.UserId, listRoleId, req.ActionUserName, req.ActionUserInfo));
                        if (!roleResult.Status)
                        {
                            res.Messages += "角色添加失败！" + roleResult.Messages;
                        }
                    }
                }
            }
            else
            {
                res.Status = result.Status;
                res.Messages = result.Messages;
            }

            return Task.FromResult(res);
        }

    }
}
