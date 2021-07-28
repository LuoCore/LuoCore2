using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui.Models
{
    public class TopBarViewModel
    {
        public ViewModels.ResultListVm<EntitysModels.System_Link> SystemLink { get; set; }
        public ViewModels.ResultListVm<EntitysModels.System_Bulletin> SystemBulletin { get; set; }
        public ViewModels.ResultListVm<EntitysModels.System_Language> SystemLanguage { get; set; }
    }
}
