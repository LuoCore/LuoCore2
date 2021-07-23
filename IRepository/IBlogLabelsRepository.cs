using DataTransferModels;
using DataTransferModels.BlogLabels.Request;
using DataTransferModels.BlogLabels.Response;
using System.Collections.Generic;
using Utility.Repository;

namespace IRepository
{
    public interface IBlogLabelsRepository : ISqlSugarRepository
    {
        public ResultDto<List<string>> ReadLabelsIdsByArticleId(string articleId);
        public ResultDto<ResponseBlogLabelListDto> ReadLabelsList(RequestQueryBlogLabelDto req);
        public ResultDto<ResponseBlogLabelPageListDto> ReadLabelsPageList(RequestQueryBlogLabelPageDto req);
        public ResultDto ReadLabelsAny(string labelsName);
        public ResultDto CreateLabels(RequestCreateBlogLabelDto req);
        public ResultDto UpdateLabels(RequestUpdateBlogLabelDto req);
        public ResultDto DeleteLabels(RequestDeleteBlogLabelDto req);
    }
}
