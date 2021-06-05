using DataTransferModels;
using DataTransferModels.BaseUser.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
    public interface IUserRepository : ISqlSugarRepository
    {
        /// <summary>
        /// 读取用户登录信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ResultDto ReadUserByLogin(LoginDto req);
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ResultDto CreateUser(RegisteredUserDto req);
    }
}
