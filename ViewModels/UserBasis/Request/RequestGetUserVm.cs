using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.UserBasis.Request
{
    public class RequestGetUserVm
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserRealName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Sex { get; set; }
        public bool? IsValid { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
