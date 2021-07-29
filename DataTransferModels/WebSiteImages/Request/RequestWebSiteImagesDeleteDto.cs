using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.WebSiteImages.Request
{
    public class RequestWebSiteImagesDeleteDto : RequestBaseDto
    {
        public RequestWebSiteImagesDeleteDto(string actionUserName, string actionUserInfo, int imageID) : base(actionUserName, actionUserInfo)
        {
            ImageID = imageID;
        }
        public int ImageID { get; set; }
    }
}
