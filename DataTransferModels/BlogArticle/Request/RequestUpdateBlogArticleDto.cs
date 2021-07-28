using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogArticle.Request
{
    public class RequestUpdateBlogArticleDto : RequestBaseDto
    {
        public RequestUpdateBlogArticleDto(string articleId, string articleTitle, string articleConten, bool isValid,string[] labelsIds,  string actionUserInfo, string actionUserName) : base(actionUserName, actionUserInfo)
        {
            ArticleId = articleId;
            ArticleTitle = articleTitle;
            ArticleConten = articleConten;
            IsValid = isValid;
            LabelsIds = labelsIds;
        }

        public string ArticleId { get; protected set; }
        public string ArticleTitle { get; protected set; }
        public string ArticleConten { get; protected set; }
        public bool IsValid { get; protected set; }

        public string[] LabelsIds { get; set; }

    }
}
