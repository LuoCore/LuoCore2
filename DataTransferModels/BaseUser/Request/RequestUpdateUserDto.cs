using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BaseUser.Request
{
    public class RequestUpdateUserDto:RequestBaseDto
    {
        public RequestUpdateUserDto(string userId, string userName, string userRealName, string password, string email, string phone, int sex,  bool isValid,string actionUserName,string actionUserInfo)
        {
            UserId = userId;
            UserName = userName;
            UserRealName = userRealName;
            Password = password;
            Email = email;
            Phone = phone;
            Sex = sex;
            IsValid = isValid;
            this.ActionUserName = actionUserName;
            this.ActionUserInfo = actionUserInfo;
        }

        public string UserId { get; protected set; }
        public string UserName { get; protected set; }
        public string UserRealName { get; protected set; }
        public string Password { get; protected set; }
        public string Email { get; protected set; }
        public string Phone { get; protected set; }
        public int Sex { get; protected set; }
        public bool IsValid { get; protected set; }
    }
}
