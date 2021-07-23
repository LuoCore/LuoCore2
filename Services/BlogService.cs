using DataTransferModels.BlogLabels.Response;
using IRepository;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using Common;

namespace Services
{
     public class BlogService : SqlSugarRepository<ISystemLogsRepository, IBlogArticleRepository, IBlogLabelsRepository>, IBlogService
     {
          public BlogService(ISqlSugarFactory factory, ISystemLogsRepository repository, IBlogArticleRepository repository2, IBlogLabelsRepository repository3) : base(factory, repository, repository2, repository3)
          {
          }

          public Task<ViewModels.Layui.TableVm> QueryBlogArticlePage(ViewModels.Blog.Request.RequestQueryArticleVm req)
          {
               ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
               var result = _REPOSITORY2.ReadArticlePageList(new DataTransferModels.BlogArticle.Request.RequestQueryBlogArticleDto(req.UserId, req.ArticleTitle, req.IsValid, req.StartTime, req.EndTime, req.PageIndex, req.PageSize));
               res.code = -1;
               if (result.Status)
               {
                    res.code = 0;
                    res.count = result.Data.PageCount;
                    res.data = result.Data.PageData;
               }
               res.msg = result.Messages;
               return Task.FromResult(res);
          }

          public Task<ViewModels.Layui.TableVm> QueryBlogLabelsPage(ViewModels.Blog.Request.RequestQueryBlogLabelPageVm req)
          {
               ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
               var result = _REPOSITORY3.ReadLabelsPageList(new DataTransferModels.BlogLabels.Request.RequestQueryBlogLabelPageDto(req.LabelId, req.LabelName, req.IsValid, req.StartTime, req.EndTime, req.PageIndex, req.PageSize));
               res.code = -1;
               if (result.Status)
               {
                    res.code = 0;
                    res.count = result.Data.PageCount;
                    res.data = result.Data.LabelDataList;
               }
               res.msg = result.Messages;
               return Task.FromResult(res);
          }

          public Task<List<ViewModels.Layui.SelectBoxVm>> QueryBlogLabelsSelectBox(ViewModels.Blog.Request.RequestQueryBlogLabelsSelectBox req)
          {
               List<ViewModels.Layui.SelectBoxVm> res = new List<ViewModels.Layui.SelectBoxVm>();

               List<string> labelIds = new List<string>();
               if (!string.IsNullOrWhiteSpace(req.ArticleId))
               {
                    var resLabelsId = _REPOSITORY3.ReadLabelsIdsByArticleId(req.ArticleId);
                    if (resLabelsId != null && resLabelsId.Status)
                    {
                         labelIds = resLabelsId.Data;
                    }
               }

               var result = _REPOSITORY3.ReadLabelsList(null);


               if (result.Status && result.Data != null && result.Data.LabelDataList != null)
               {
                    foreach (ResponseBlogLabelDto m in result.Data.LabelDataList)
                    {
                         var selectData = new ViewModels.Layui.SelectBoxVm()
                         {
                              Name = m.LabelName,
                              value = m.LabelId
                         };
                         selectData.selected = labelIds.Where(x => x == m.LabelId).Any();
                         res.Add(selectData);
                    }
               }
               return Task.FromResult(res);
          }

          public Task<ViewModels.ResultVm> CreateBlogLabels(ViewModels.Blog.Request.RequestCreateBlogLabelVm req)
          {
               ViewModels.ResultVm res = new ViewModels.ResultVm();
               var resAny = _REPOSITORY3.ReadLabelsAny(req.LabelName);
               if (resAny != null && resAny.Status)
               {
                    res.Messages = "该分类名称已存在！";
                    res.Status = false;
                    return Task.FromResult(res);
               }
               var result = _REPOSITORY3.CreateLabels(new DataTransferModels.BlogLabels.Request.RequestCreateBlogLabelDto(Guid.NewGuid(), req.LabelName, req.LabelDescribe, req.IsValid, _REPOSITORY.GetNowDateTime(), req.ActionUserName, req.ActionUserInfo));
               res.Messages = result.Messages;
               res.Status = result.Status;
               return Task.FromResult(res);
          }
          public Task<ViewModels.ResultVm> UpdateBlogLabels(ViewModels.Blog.Request.RequestUpdateBlogLabelVm req)
          {
               ViewModels.ResultVm res = new ViewModels.ResultVm();
               var result = _REPOSITORY3.UpdateLabels(new DataTransferModels.BlogLabels.Request.RequestUpdateBlogLabelDto(req.LabelId, req.LabelName, req.LabelDescribe, req.IsValid, req.ActionUserName, req.ActionUserInfo));
               res.Messages = result.Messages;
               res.Status = result.Status;
               return Task.FromResult(res);
          }

          public Task<ViewModels.ResultVm> DeleteBlogLabels(string[] ids, string userName, string userInfo)
          {
               ViewModels.ResultVm res = new ViewModels.ResultVm();
               int exceuIndex = 0;
               foreach (string strId in ids)
               {
                    var result = _REPOSITORY3.DeleteLabels(new DataTransferModels.BlogLabels.Request.RequestDeleteBlogLabelDto(strId, userName, userInfo));
                    if (result != null && result.Status)
                    {
                         exceuIndex += 1;
                    }
               }

               res.Messages = "成功删除：" + exceuIndex + "条。";
               res.Status = true;
               return Task.FromResult(res);
          }

          public Task<ViewModels.ResultVm> CreateBlogArticle(ViewModels.Blog.Request.RequestCreateBlogArticleVm req)
          {
               ViewModels.ResultVm res = new ViewModels.ResultVm();

               string[] labIds = req.LabelsIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

               EntitysModels.Base_User userInfo = req.ActionUserInfo.ToObject<EntitysModels.Base_User>();
               req.UserId = userInfo.UserId;
               var result = _REPOSITORY2.CreateArticle(new DataTransferModels.BlogArticle.Request.RequestCreateBlogArticleDto(req.UserId, req.ArticleTitle, req.ArticleConten, req.IsValid, _REPOSITORY.GetNowDateTime(), labIds, req.ActionUserInfo, req.ActionUserName));
               res.Messages = result.Messages;
               res.Status = result.Status;
               return Task.FromResult(res);
          }

          public Task<ViewModels.ResultVm> UpdateBlogArticle(ViewModels.Blog.Request.RequestUpdateBlogArticleVm req)
          {
               ViewModels.ResultVm res = new ViewModels.ResultVm();

               string[] labIds = req.LabelsIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
               var result = _REPOSITORY2.UpdateArticleById(new DataTransferModels.BlogArticle.Request.RequestUpdateBlogArticleDto(req.ArticleId, req.ArticleTitle, req.ArticleConten, req.IsValid, labIds, req.ActionUserInfo, req.ActionUserName));
               res.Messages = result.Messages;
               res.Status = result.Status;
               return Task.FromResult(res);
          }

          public Task<ViewModels.ResultVm> DeleteBlogArticle(ViewModels.Blog.Request.RequestDeleteBlogArticleVm req)
          {
               ViewModels.ResultVm res = new ViewModels.ResultVm();
               if (req == null|| req.ArticleIds == null || req.ArticleIds.Length < 1)
               {
                    res.Messages = "没有需要删除的信息！";
                    res.Status = false;
                    return Task.FromResult(res);
               }
               int exceIndex = 0;
               foreach (var s in req.ArticleIds)
               {
                    var result = _REPOSITORY2.DeleteArticleById(new DataTransferModels.BlogArticle.Request.RequestDeleteBlogArticleDto(s, req.ActionUserInfo, req.ActionUserName));
                    if (result != null && result.Status)
                    {
                         exceIndex += 1;
                    }
               }

               res.Messages = "成功删除：" + exceIndex + "条！";
               res.Status = true;
               return Task.FromResult(res);
          }
     }
}
