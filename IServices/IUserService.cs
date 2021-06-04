using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.User.Request;

namespace IServices
{
    public interface IUserService
    {
        public Task<ResultVm> UserLogin(UserLoginVm req);
    }
}
