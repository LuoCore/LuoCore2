using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogLabels.Request
{
    public class RequestQueryBlogLabelDto
    {
        public RequestQueryBlogLabelDto(string labelId, string labelName, DateTime? startTime, DateTime? endTime)
        {
            LabelId = labelId;
            LabelName = labelName;
            StartTime = startTime;
            EndTime = endTime;
        }

        public string LabelId { get; protected set; }
        public string LabelName { get; protected set; }
        public DateTime? StartTime { get; protected set; }
        public DateTime? EndTime { get; protected set; }
    }
}
