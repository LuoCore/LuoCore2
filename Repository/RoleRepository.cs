using DataTransferModels;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using EntitysModels;
using DataTransferModels.BsaeRole;
using Nancy;
using DataTransferModels.BsaeRole.Request;
using DataTransferModels.BsaeRole.Response;

namespace Repository
{
    public class RoleRepository : SqlSugarRepository<ISystemLogsRepository>, IRoleRepository
    {
        public RoleRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
        {
        }


        public ResultDto<ResponseRolePageDto> ReadRolePageList(RequestQueryRoleDto req)
        {
            ResultDto<ResponseRolePageDto> res = new ResultDto<ResponseRolePageDto>();
            try
            {
                ResponseRolePageDto result = new ResponseRolePageDto();
                _FACTORY.GetDbContext((db) =>
                {
                    int pageCount = 0;
                    result.PageList=db.Queryable<Bsae_Role>()
                    .WhereIF(!string.IsNullOrWhiteSpace(req.RoleId), x => x.RoleId.Equals(req.RoleId))
                    .WhereIF(!string.IsNullOrWhiteSpace(req.RoleName), x => x.RoleId.Equals(req.RoleName))
                    .WhereIF(!Equals(req.IsValid), x => x.IsValid.Equals(req.IsValid))
                    .Select(x=>new ResponseRoleDto() 
                    {
                        RoleId=x.RoleId,
                        RoleName=x.RoleName,
                        RoleDescription=x.RoleDescription,
                        IsValid=x.IsValid,
                        CreateName=x.CreateName,
                        CreateTime=x.CreateTime
                    })
                    .ToPageList(req.PageIndex,req.PageSize,ref pageCount);
                    result.PageCount = pageCount;
                    res.Status = true;
                    res.Data = result;
                });
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Messages = ex.Message;
            }
            return res;
            
        }
    }
}
