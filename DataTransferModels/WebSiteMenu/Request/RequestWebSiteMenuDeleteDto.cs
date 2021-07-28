using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.WebSiteMenu.Request
{
    public class RequestWebSiteMenuDeleteDto:RequestBaseDto
    {
        public RequestWebSiteMenuDeleteDto(int menuID, string actionUserName, string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
            MenuID = menuID;
        }

   

        public int MenuID { get; protected set; }
    }
}
