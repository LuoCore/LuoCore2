using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.WebSiteMenu.Request
{
    public class RequestWebSiteMenuReadDto
    {
        public RequestWebSiteMenuReadDto(int menuID, string menuName, int? menuPid, bool? isvalid)
        {
            MenuID = menuID;
            MenuName = menuName;
            MenuPid = menuPid;
            IsValid = isvalid;
        }

        public int MenuID { get; protected set; }
        public string MenuName { get; protected set; }
      
        public int? MenuPid { get; protected set; }
        public bool? IsValid { get; protected set; }
    }
}
