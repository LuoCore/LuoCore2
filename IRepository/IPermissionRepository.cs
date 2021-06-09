using DataTransferModels;
using DataTransferModels.BasePermission.Request;
using DataTransferModels.BasePermission.Response;
using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
    public interface IPermissionRepository : ISqlSugarRepository
    {
        /// <summary>
        /// 按父级ID查询
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public ResultDto<List<Base_Permission>> ReadPermissionByParentId(string parentId);

        public ResultDto<ResponsePermissionListDto> ReadPermissionTableData(RequestWherePermissionDto req);
        public ResultDto CreatePermission(RequestCreatePermissionDto req);
        public ResultDto UpdatePermission(RequesUpdatePermissionDto req);
    }
}
