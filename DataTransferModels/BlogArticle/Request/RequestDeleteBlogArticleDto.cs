using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogArticle.Request
{
    public class RequestDeleteBlogArticleDto : RequestBaseDto
    {
        public RequestDeleteBlogArticleDto(string articleId,string actionUserInfo,string actionUserName)
        {
            ArticleId = articleId;
            this.ActionUserInfo = actionUserInfo;
            this.ActionUserName = actionUserName;
        }

        public string ArticleId { get; protected set; }
    }
}
