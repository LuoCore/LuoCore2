using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogLabels.Request
{
    public class RequestCreateBlogLabelDto : RequestBaseDto
    {
        public RequestCreateBlogLabelDto(Guid  labelId, string labelName, string labelDescribe, bool isValid, DateTime createTime,string actionUserName,string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
          
            LabelId = labelId;
            LabelName = labelName;
            LabelDescribe = labelDescribe;
            IsValid = isValid;
            CreateTime = createTime;
        }


        public Guid LabelId { get; set; }
        public string LabelName { get; set; }
        public string LabelDescribe { get; set; }
        public bool IsValid { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
