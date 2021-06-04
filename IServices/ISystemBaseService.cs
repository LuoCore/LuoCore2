using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Request;

namespace IServices
{
    public interface ISystemBaseService
    {
        public Task<ResultVm> UserLogin(UserLoginVm req);
    }
}
