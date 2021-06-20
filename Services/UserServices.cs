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
using ViewModels.User.Request;
using ViewModels.User.Response;

namespace Services
{
    public class UserServices : SqlSugarRepository<ISystemLogsRepository,IUserRepository,IPermissionRepository>, IUserServices
    {
        public UserServices(ISqlSugarFactory factory, ISystemLogsRepository repository, IUserRepository repository2,IPermissionRepository repository3) : base(factory, repository, repository2,repository3)
        {
        }


        /// <summary>
        /// 用户登录
        /// </summary>
        public Task<ResultVm<ResponseUserLoginVM>> LoginUser(RequestUserLoginVm req) 
        {
            ResultVm<ResponseUserLoginVM> res = new ResultVm<ResponseUserLoginVM>();
            if (!req.SecurityCode.Equals(req.VerifiCode)) 
            {
                res.Messages = "验证码错误！";
                res.Status = false;
                return Task.FromResult(res);
            }
            var result= _REPOSITORY2.ReadUserByLogin(new DataTransferModels.BaseUser.Request.RequsetLoginDto(req.UserName,req.Password));
           
            if (Equals(null, result.Data)) 
            {
                res.Messages = "用户名或密码错误！";
                res.Status = false;
                return Task.FromResult(res);
            }
            res.Data = new ResponseUserLoginVM();
            res.Data.UserInfo = result.Data;
            var userRolesPermission= _REPOSITORY3.ReadPermissionsByUserId(res.Data.UserInfo.UserId);
            if (!Equals(null, userRolesPermission))
            {
                res.Data.PermissionInfo = userRolesPermission;
            }

            res.Messages = "登录成功！";
            res.Status = true;
            
            return Task.FromResult(res);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        public Task<ResultVm> RegisteredUser(RequestRegisteredUserVm req)
        {
            ResultVm res = new ResultVm();
            if (!req.SecurityCode.Equals(req.Vercode))
            {
                res.Messages = "验证码错误！";
                res.Status = false;
                return Task.FromResult(res);
            }
            if (!req.PasswordVerify.Equals(req.Password))
            {
                res.Messages = "确认密码和密码不对应！";
                res.Status = false;
                return Task.FromResult(res);
            }
            
            var result = _REPOSITORY2.CreateUser(new DataTransferModels.BaseUser.Request.RequsetRegisteredUserDto(Guid.NewGuid(),req.UserName,req.RealName,req.Password,req.Email,req.Phone,req.Sex,_REPOSITORY.GetNowDateTime(),true,System.Environment.UserName,""));
            res.Messages = result.Messages;
            res.Status = result.Status;
            return Task.FromResult(res);
        }
    }
}
