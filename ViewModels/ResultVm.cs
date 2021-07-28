using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ResultVm<T>
    {
        public bool Status { get; set; }
        public string Messages { get; set; }
        public T Data { get; set; }
    }
     public class ResultListVm<T>
     {
          public bool Status { get; set; }
          public string Messages { get; set; }
          public List<T> Datas { get; set; }
     }
     public class ResultVm
    {
        public bool Status { get; set; }
        public string Messages { get; set; }
        public dynamic Data { get; set; }

    }
}
