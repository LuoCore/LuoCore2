using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels
{
    public class RequestBaseDto
    {
        public string UserName { get; protected set; }
        public string UserInfo { get; protected set; }
    }
}
