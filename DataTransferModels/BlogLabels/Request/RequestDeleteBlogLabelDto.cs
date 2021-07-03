using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogLabels.Request
{
    public class RequestDeleteBlogLabelDto : RequestBaseDto
    {
        public string LabelId { get; set; }

        public RequestDeleteBlogLabelDto(string labelId,string actionUserName,string actionUserInfo)
        {
            LabelId = labelId;
            this.ActionUserName = actionUserName;
            this.ActionUserInfo = actionUserInfo;
        }
    }
}
