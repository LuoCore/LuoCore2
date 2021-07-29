using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.WebSiteImages.Request
{
    public class RequestWebSiteImagesUpdateDto : RequestWebSiteImagesCreateDto
    {
        public RequestWebSiteImagesUpdateDto(string actionUserName, string actionUserInfo, string favicon16 = null, string favicon32 = null, string maskIcon = null, string logoBrand = null, string logoBrandAlt = null, bool isValid = false, int imageID = 0) : base(actionUserName, actionUserInfo, favicon16, favicon32, maskIcon, logoBrand, logoBrandAlt, isValid)
        {
            ImageID = imageID;
        }

        public int ImageID { get; set; }
    }
}
