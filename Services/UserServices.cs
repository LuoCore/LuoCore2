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

namespace Services
{
    public class UserServices : SqlSugarRepository<ISystemLogsRepository,IUserRepository>, IUserServices
    {
        public UserServices(ISqlSugarFactory factory, ISystemLogsRepository repository, IUserRepository repository2) : base(factory, repository, repository2)
        {
        }


        /// <summary>
        /// 用户登录
        /// </summary>
        public Task<ResultVm> LoginUser(RequestUserLoginVm req) 
        {
            ResultVm res = new ResultVm();
            if (!req.SecurityCode.Equals(req.VerifiCode)) 
            {
                res.Messages = "验证码错误！";
                res.Status = false;
                return Task.FromResult(res);
            }
            var result= _REPOSITORY2.ReadUserByLogin(new DataTransferModels.BaseUser.Request.RequsetLoginDto(req.UserName,req.Password));
            res.Data = result.Data;
            if (Equals(null, res.Data)) 
            {
                res.Messages = "用户名或密码错误！";
                res.Status = false;
                return Task.FromResult(res);
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
            
            var result = _REPOSITORY2.CreateUser(new DataTransferModels.BaseUser.Request.RequsetRegisteredUserDto(Guid.NewGuid(),req.UserName,req.RealName,req.Password,req.Email,req.Phone,req.Sex,_REPOSITORY.GetNowDateTime(),req.CreateName,true));
            res.Messages = result.Messages;
            res.Status = result.Status;
            return Task.FromResult(res);
        }
    }
}
