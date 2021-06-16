using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BsaeRole.Response
{
    public class ResponseRoleDto
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateName { get; set; }
        public bool IsValid { get; set; }
    }
}
