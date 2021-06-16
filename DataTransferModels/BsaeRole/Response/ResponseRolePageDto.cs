using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BsaeRole.Response
{
    public class ResponseRolePageDto
    {

        public List<ResponseRoleDto> PageList { get; set; }
        public int PageCount { get; set; }
    }
}
