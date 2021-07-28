using DataTransferModels;
using DataTransferModels.WebSiteMenu.Request;
using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
    public interface IWebSiteMenuRepository : ISqlSugarRepository
    {
        public ResultListDto<WebSite_Menu> ReadWebSiteMenuPage(RequestWebSiteMenuReadPageDto req);
        public ResultListDto<WebSite_Menu> ReadWebSiteMenuList(RequestWebSiteMenuReadDto req);
        public ResultDto CreateWebSiteMenu(RequestWebSiteMenuCreateDto req);
        public ResultDto UpdateWebSiteMenu(RequestWebSiteMenuUpdateDto req);
        public ResultDto DeleteWebSiteMenu(RequestWebSiteMenuDeleteDto req);
    }
}
