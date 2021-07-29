using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.WebSiteMenu.Request
{
    public class RequestWebSiteMenuReadPageDto : RequestWebSiteMenuReadDto
    {
        public RequestWebSiteMenuReadPageDto(int menuID, string menuName, int? menuPid, bool? isVail,int pageIndex,int pageSize) : base(menuID, menuName, menuPid, isVail)
        {
            this.PageIndex = pageIndex;
            this.PageSize = PageSize;
        }

        public int PageIndex { get; protected set; }
        public int PageSize { get; protected set; }
    }
}
