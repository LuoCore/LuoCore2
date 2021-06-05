using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.User.Request;

namespace IServices
{
    public interface IUserServices
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        public Task<ResultVm> LoginUser(UserLoginVm req);
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<ResultVm> RegisteredUser(RegisteredUserVm req);
    }
}
