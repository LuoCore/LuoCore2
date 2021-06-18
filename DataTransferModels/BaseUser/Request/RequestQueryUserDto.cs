using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BaseUser.Request
{
    public class RequestQueryUserDto
    {
        public RequestQueryUserDto(string userId, string userName, string userRealName, string email, string phone, int? sex, bool? isValid, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize)
        {
            UserId = userId;
            UserName = userName;
            UserRealName = userRealName;
            Email = email;
            Phone = phone;
            Sex = sex;
            IsValid = isValid;
            StartTime = startTime;
            EndTime = endTime;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public string UserId { get; protected set; }
        public string UserName { get; protected set; }
        public string UserRealName { get; protected set; }
        public string Email { get; protected set; }
        public string Phone { get; protected set; }
        public int? Sex { get; protected set; }
        public bool? IsValid { get; protected set; }
        public DateTime? StartTime { get; protected set; }
        public DateTime? EndTime { get; protected set; }
        public int PageIndex { get; protected set; }
        public int PageSize { get; protected set; }
    }
}
