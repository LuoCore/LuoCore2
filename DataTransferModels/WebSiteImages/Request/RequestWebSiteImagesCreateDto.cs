using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.WebSiteImages.Request
{
    public class RequestWebSiteImagesCreateDto:RequestBaseDto
    {
        public RequestWebSiteImagesCreateDto(string actionUserName, string actionUserInfo, string favicon16 = null, string favicon32 = null, string maskIcon = null, string logoBrand = null, string logoBrandAlt = null, bool isValid = false) : base(actionUserName, actionUserInfo)
        {
            Favicon16 = favicon16;
            Favicon32 = favicon32;
            MaskIcon = maskIcon;
            LogoBrand = logoBrand;
            LogoBrandAlt = logoBrandAlt;
            IsValid = isValid;
        }

        public string Favicon16 { get; set; }
        public string Favicon32 { get; set; }
        public string MaskIcon { get; set; }
        public string LogoBrand { get; set; }
        public string LogoBrandAlt { get; set; }
        public bool IsValid { get; set; }
    }
}
