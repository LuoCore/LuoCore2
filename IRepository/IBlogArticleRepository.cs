using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;
using DataTransferModels;

namespace IRepository
{
   public interface IBlogArticleRepository : ISqlSugarRepository
    {
        public DataTransferModels.ResultDto<DataTransferModels.BlogArticle.Response.ResponseBlogArticlePageDto> ReadArticlePageList(DataTransferModels.BlogArticle.Request.RequestQueryBlogArticleDto req);
        public ResultDto CreateArticle(DataTransferModels.BlogArticle.Request.RequestCreateBlogArticleDto req);
        public ResultDto UpdateArticleById(DataTransferModels.BlogArticle.Request.RequestUpdateBlogArticleDto req);
        public ResultDto DeleteArticleById(DataTransferModels.BlogArticle.Request.RequestDeleteBlogArticleDto req);
    }
}
