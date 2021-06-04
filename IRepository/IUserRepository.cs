using DataTransferModels;
using DataTransferModels.BaseUser.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
    public interface IUserRepository : ISqlSugarRepository
    {
        public ResultDto ReadFirstByLogin(LoginDto req);
    }
}
