using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BlogArticle.Response
{
    public class ResponseBlogArticlePageDto
    {
        public int PageCount { get; set; }
        public List<ResponseBlogArticleDto> PageData { get; set; }

    }
}
