using DataTransferModels;
using DataTransferModels.BlogLabels.Request;
using DataTransferModels.BlogLabels.Response;
using Utility.Repository;

namespace IRepository
{
    public interface IBlogLabelsRepository : ISqlSugarRepository
    {
        public ResultDto<ResponseBlogLabelListDto> ReadLabelsList(RequestQueryBlogLabelDto req);
        public ResultDto<ResponseBlogLabelPageListDto> ReadLabelsPageList(RequestQueryBlogLabelPageDto req);
        public ResultDto CreateLabels(RequestCreateBlogLabelDto req);
        public ResultDto UpdateLabels(RequestUpdateBlogLabelDto req);
        public ResultDto DeleteLabels(RequestDeleteBlogLabelDto req);
    }
}
