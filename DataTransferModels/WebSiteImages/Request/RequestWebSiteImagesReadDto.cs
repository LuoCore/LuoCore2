using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.WebSiteImages.Request
{
    public class RequestWebSiteImagesReadDto
    {
        public RequestWebSiteImagesReadDto(int imageID, bool? isValid)
        {
            ImageID = imageID;
            IsValid = isValid;
        }

        public int ImageID { get; set; }
        public bool? IsValid { get; set; }
    }
}
