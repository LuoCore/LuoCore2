using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.WebSiteImages.Request
{
    public class RequestWebSiteImagesReadPageDto : RequestWebSiteImagesReadDto
    {
        public RequestWebSiteImagesReadPageDto(int imageID, bool? isValid, int pageIndex, int pageSize) : base(imageID, isValid)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
