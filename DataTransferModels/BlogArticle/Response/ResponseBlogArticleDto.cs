using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogArticle.Response
{
   public class ResponseBlogArticleDto
    {
        public string UserId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleConten { get; set; }
        public bool IsValid { get; set; }
    }
}
