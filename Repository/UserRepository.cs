using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using EntitysModels;
using DataTransferModels.BaseUser.Request;
using DataTransferModels;
using Common;
using EnumHelper;

namespace Repository
{
    public class UserRepository : SqlSugarRepository<ISystemLogsRepository>, IUserRepository
    {
        public UserRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
        {

        }
        /// <summary>
        /// 读取用户登录信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ResultDto ReadUserByLogin(RequsetLoginDto req)
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    res.Status = true;
                    res.Data = db.Queryable<Base_User>()
                    .Where(x => x.UserName.Equals(req.UserName) && x.Password.Equals(req.Password))
                    .First();
                });
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Messages = ex.Message;
            }
            return res;
        }


        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ResultDto CreateUser(RequsetRegisteredUserDto req)
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    var userData = new
                    {
                        UserId = req.UserId,
                        UserName = req.UserName,
                        UserRealName = req.UserRealName,
                        Password = req.Password,
                        Phone = req.Phone,
                        Email = req.Email,
                        Sex = req.Sex,
                        CreateName = req.CreateName,
                        CreateTime = req.CreateTime,
                        IsValid = req.IsValid
                    };
                    db.Insertable<Base_User>(userData).IgnoreColumns(ignoreNullColumn: true).ExecuteCommandIdentityIntoEntity();
                    _REPOSITORY.LogSave<Base_User>(db,CURDEnum.创建, userData,null,Environment.UserName,string.Empty).ExecuteCommand();
                });
                res.Status = true;
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
