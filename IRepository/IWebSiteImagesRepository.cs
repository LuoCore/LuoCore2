using DataTransferModels;
using DataTransferModels.WebSiteImages.Request;
using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
    public interface IWebSiteImagesRepository : ISqlSugarRepository
    {
        public ResultListDto<WebSite_Images> ReadWebSiteImagesPage(RequestWebSiteImagesReadPageDto req);
        public ResultDto CreateWebSiteImages(RequestWebSiteImagesCreateDto req);
        public ResultDto UpdateWebSiteImages(RequestWebSiteImagesUpdateDto req);
        public ResultDto DeleteWebSiteImages(RequestWebSiteImagesDeleteDto req);
    }
}
