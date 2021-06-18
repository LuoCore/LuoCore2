using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Layui
{
    public class TreeVm
    {
        public string id { get; set; }
        public string title { get; set; }
        public bool @checked { get; set; }
        public bool disabled { get; set; }
        public List<TreeVm> children { get; set; }
    }
}
