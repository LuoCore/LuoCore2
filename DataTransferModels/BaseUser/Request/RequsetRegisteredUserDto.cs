using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BaseUser.Request
{
   public class RequsetRegisteredUserDto:RequestBaseDto
    {
        public RequsetRegisteredUserDto(Guid userId, string userName, string userRealName, string password, string email, string phone, int sex, DateTime createTime, bool isValid, string actionUserName, string actionUserInfo)
        {
            UserId = userId;
            UserName = userName;
            UserRealName = userRealName;
            Password = password;
            Email = email;
            Phone = phone;
            Sex = sex;
            CreateTime = createTime;
            ActionUserName = actionUserName;
            ActionUserInfo = actionUserInfo;
            IsValid = isValid;
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public Guid UserId { get;protected set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string UserName { get; protected set; }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string UserRealName { get; protected set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Password { get; protected set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Email { get; protected set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Phone { get; protected set; }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int Sex { get; protected set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateTime { get; protected set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public bool IsValid { get; protected set; }
    }
}
