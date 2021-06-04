using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BaseUser.Request
{
    public class LoginDto : BaseUserDto
    {
        public LoginDto(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
