using DataTransferModels.BaseUser.Request;
using IRepository;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using ViewModels;
using ViewModels.User.Request;

namespace Services
{
    public class UserService : BaseService<IUserRepository>, IUserService
    {
        public UserService(ISqlSugarFactory factory, ISystemLogsRepository logsRepository, IUserRepository repository) : base(factory, logsRepository, repository)
        {
        }

        public Task<ResultVm> UserLogin(UserLoginVm req)
        {
            ResultVm res = new ResultVm() { Status = true };
            res.Data = DbRepository.ReadFirstByLogin(new LoginDto(req.UserName, req.Password));
            return Task.FromResult(res);
        }
    }
}
