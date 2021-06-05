using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Layui
{
    public class SelectBoxVm
    {
        public string value { get; set; }
        public string Name { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }
        public List<SelectBoxVm> children { get; set; }
    }
}
