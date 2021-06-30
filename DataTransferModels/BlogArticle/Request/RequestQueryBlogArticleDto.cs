using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogArticle.Request
{
    public class RequestQueryBlogArticleDto
    {
        public RequestQueryBlogArticleDto(string userId,string articleTitle,  bool? isValid, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize)
        {
            UserId = userId;
            ArticleTitle = articleTitle;
            IsValid = isValid;
            StartTime = startTime;
            EndTime = endTime;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public string UserId { get; protected set; }
        public string ArticleTitle { get; protected set; }
        public bool? IsValid { get; protected set; }
        public DateTime? StartTime { get; protected set; }
        public DateTime? EndTime { get; protected set; }
        public int PageIndex { get; protected set; }
        public int PageSize { get; protected set; }
    }
}
