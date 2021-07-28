using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels
{
    public class ResultDto<T>
    {
        public bool Status { get; set; }
        public string Messages { get; set; }
        public int DataCount { get; set; }
        public T Data { get; set; }
    }
    public class ResultListDto<T>
    {
        public bool Status { get; set; }
        public string Messages { get; set; }
        public int DatasCount { get; set; }
        public List<T> Datas { get; set; }
    }
    public class ResultDto
    {
        public bool Status { get; set; }
        public string Messages { get; set; }
        public int DataCount { get; set; }
        public dynamic Data { get; set; }

    }
}
