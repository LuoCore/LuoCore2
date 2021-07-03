using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogLabels.Response
{
    public class ResponseBlogLabelPageListDto
    {
        public List<ResponseBlogLabelDto> LabelDataList { get; set; }
        public int PageCount { get; set; }
    }
}
