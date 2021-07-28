using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.WebSiteMenu.Request
{
    public class RequestWebSiteMenuUpdateDto : RequestWebSiteMenuCreateDto
    {
        public RequestWebSiteMenuUpdateDto(int menuID, string menuName, string menuUrl, int menuPid, bool isValid, string actioUserName, string actionUserInfo) : base(menuName, menuUrl, menuPid, isValid, actioUserName, actionUserInfo)
        {
            MenuID = menuID;
        }
        public int MenuID { get; protected set; }
    }
}
