using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.WebSiteMenu.Request
{
    public class RequestWebSiteMenuCreateDto:RequestBaseDto
    {
     

        public RequestWebSiteMenuCreateDto(string menuName, string menuUrl, int menuPid, bool isValid,string actionUserName,string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
            MenuName = menuName;
            MenuUrl = menuUrl;
            MenuPid = menuPid;
            IsValid = isValid;
        }

        public string MenuName { get;protected set; }
        public string MenuUrl { get; protected set; }
        public int MenuPid { get; protected set; }
        public bool IsValid { get; protected set; }
    }
}
