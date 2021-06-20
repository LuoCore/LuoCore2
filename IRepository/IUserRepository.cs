using DataTransferModels;
using DataTransferModels.BaseUser.Request;
using DataTransferModels.BaseUser.Response;
using EntitysModels;
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
        public ResultDto<Base_User> ReadUserByLogin(RequsetLoginDto req);
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ResultDto CreateUser(RequsetRegisteredUserDto req);

        public ResultDto<ResponseUserPageDto> ReadUserPageList(RequestQueryUserDto req);
        public ResultDto UpdateUserById(RequestUpdateUserDto req);
        public ResultDto<Base_User> ReadUserById(string userId);
    }
}
