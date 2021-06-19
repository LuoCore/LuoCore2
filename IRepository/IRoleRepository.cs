using DataTransferModels;
using DataTransferModels.BsaeRole.Request;
using DataTransferModels.BsaeRole.Response;
using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
    public interface IRoleRepository : ISqlSugarRepository
    {
        public ResultDto<ResponseRolePageDto> ReadRolePageList(RequestQueryRoleDto req);
        public ResultDto CreateRole(RequestCreateRoleDto req);
        public Base_Role ReadRoleById(string roleId);
        public List<Base_Role> ReadValidRoleList();
    }
}
