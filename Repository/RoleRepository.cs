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
              
                _FACTORY.GetDbContext((db) =>
                {
                    int pageCount = 0;
                    var roleList=db.Queryable<Base_Role>()
                    .WhereIF(!string.IsNullOrWhiteSpace(req.RoleId), x => x.RoleId.Equals(req.RoleId))
                    .WhereIF(!string.IsNullOrWhiteSpace(req.RoleName), x => x.RoleId.Equals(req.RoleName))
                    .WhereIF(!Equals(null,req.IsValid), x => x.IsValid.Equals(req.IsValid))
                    .ToPageList(req.PageIndex,req.PageSize,ref pageCount);
                    res.Data = new ResponseRolePageDto(roleList, pageCount);
                    res.Status = true;
                });
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Messages = ex.Message;
            }
            return res;
            
        }

        public ResultDto CreateRole(RequestCreateRoleDto req) 
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    var insetData = new
                    {
                        RoleId = req.RoleId,
                        RoleName = req.RoleName,
                        RoleDescription = req.RoleDescription,
                        CreateTime = req.CreateTime,
                        CreateName = req.UserName,
                        IsValid = req.IsValid
                    };
                    Base_Role roleData = db.Insertable<Base_Role>(insetData).ExecuteReturnEntity();
                    _REPOSITORY.LogSave<Base_Role>(db, EnumHelper.CURDEnum.创建, insetData, null, req.UserName, req.UserInfo).ExecuteCommand();
                });
                res.Status = true;
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Messages=ex.Message;
            }
            return res;
        }


        public Base_Role ReadRoleById(string roleId)
        {
            Base_Role res = new Base_Role();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    res = db.Queryable<Base_Role>().Where(x=>x.RoleId.Equals(roleId)).First();
                });
            }
            catch (Exception ex)
            {
                res = null;
            }
            return res;
        }


        
    }
}
