using IRepository;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using ViewModels;

namespace Services
{
    public class SystemBaseService : BaseService<IUserRepository>, ISystemBaseService
    {
        public SystemBaseService(ISqlSugarFactory factory, ISystemLogsRepository logsRepository, IUserRepository repository) : base(factory, logsRepository, repository)
        {

        }

        public Task<ResultVm> UserLogin(UserLoginVm req)
        {
            ResultVm res = new ResultVm() { Status = true };
            res.Data= DbRepository.ReadFirstByLogin(new DataTransferModels.Request.User.LoginDto(req.UserName,req.Password));
            return Task.FromResult(res);
        }
    }
}
