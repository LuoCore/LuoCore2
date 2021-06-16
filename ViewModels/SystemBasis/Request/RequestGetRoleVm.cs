using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
    public class RequestGetRoleVm
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsValid { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
