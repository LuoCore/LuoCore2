using DataTransferModels;
using DataTransferModels.BaseUserRole.Request;
using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
    public interface IUserRoleRepository : ISqlSugarRepository
    {
        public ResultDto CreateUserRole(RequestCreateUserRoleDto req);
        public ResultDto<List<Base_UserRole>> ReadUserRoleByUserId(string userId);
    }
}
