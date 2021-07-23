using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.UserBasis.Request
{
    public class RequestCreateEntityVm : RequestBaseVm
    {
        public string DirectoryPath { get; set; }
        public string NameSpace { get; set; }
    }
}
