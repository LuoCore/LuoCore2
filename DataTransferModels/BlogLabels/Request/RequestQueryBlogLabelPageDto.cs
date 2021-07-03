using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogLabels.Request
{
    public class RequestQueryBlogLabelPageDto
    {
        public RequestQueryBlogLabelPageDto(string labelId, string labelName, bool? isValid, DateTime? startTime, DateTime? endTime,int pageIndex,int pageSize)
        {
            LabelId = labelId;
            LabelName = labelName;
            IsValid = isValid;
            StartTime = startTime;
            EndTime = endTime;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }

        public string LabelId { get; protected set; }
        public string LabelName { get; protected set; }
        public bool? IsValid { get; protected set; }
        public DateTime? StartTime { get; protected set; }
        public DateTime? EndTime { get; protected set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
