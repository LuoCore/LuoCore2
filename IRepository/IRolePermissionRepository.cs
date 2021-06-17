using DataTransferModels;
using DataTransferModels.BaseRolePermission.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
    public interface IRolePermissionRepository : ISqlSugarRepository
    {
        public ResultDto CreateRolePermission(RequestCreateRolePermissionDto req);
    }
}
