using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogArticle.Request
{
    public class RequestDeleteBlogArticleDto : RequestBaseDto
    {
        public RequestDeleteBlogArticleDto(string articleId,string actionUserInfo,string actionUserName) : base(actionUserName, actionUserInfo)
        {
            ArticleId = articleId;
        }

        public string ArticleId { get; protected set; }
    }
}
