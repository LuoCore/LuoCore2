using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogArticle.Request
{
    public class RequestCreateBlogArticleDto:RequestBaseDto
    {
        public RequestCreateBlogArticleDto(string userId, string articleTitle, string articleConten, bool isValid, DateTime createTime,string[] labelsIds, string actionUserInfo,string actionUsername)
        {
            UserId = userId;
            ArticleTitle = articleTitle;
            ArticleConten = articleConten;
            IsValid = isValid;
            CreateTime = createTime;
            LabelsIds = labelsIds;
            this.ActionUserInfo = actionUserInfo;
            this.ActionUserName = actionUsername;
        }

        public string UserId { get; protected set; }
        public string ArticleTitle { get; protected set; }
        public string ArticleConten { get; protected set; }
        public bool IsValid { get; protected set; }
        public DateTime CreateTime { get; protected set; }

        public string[] LabelsIds { get; protected set; }
      
    }
}
