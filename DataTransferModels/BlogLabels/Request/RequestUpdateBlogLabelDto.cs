using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogLabels.Request
{
    public class RequestUpdateBlogLabelDto:RequestBaseDto
    {
        public RequestUpdateBlogLabelDto(string labelId,string labelName, string labelDescribe, bool isValid,string actionUserName,string actionUserInfo)
        {
            LabelId = labelId;
            LabelName = labelName;
            LabelDescribe = labelDescribe;
            IsValid = isValid;
            this.ActionUserName = actionUserName;
            this.ActionUserInfo = actionUserInfo;
        }
        public string LabelId { get; set; }
        public string LabelName { get; set; }
        public string LabelDescribe { get; set; }
        public bool IsValid { get; set; }
    }
}
