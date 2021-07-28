using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.SystemBasis.Request;

namespace IServices
{
     public interface ISystemBasisService
     {
          public Task<ViewModels.Layui.TableVm> QueryLinkPage(RequestLinkQueryPageVm req);
          public Task<ResultListVm<EntitysModels.System_Link>> QueryLinks(RequestQueryLinkVm req);
          public Task<ResultVm> CreateLink(RequestLinkCreateVm req);
          public Task<ResultVm> UpdateLink(RequestLinkUpdateVm req);
          public Task<ResultVm> DeleteLink(RequestLinkDeleteVm req);

          public Task<ViewModels.Layui.TableVm> QueryLanguagePage(RequestLanguageQueryPageVm req);
        public Task<ResultListVm<EntitysModels.System_Language>> QueryLanguageList(RequestLanguageQueryVm req);
          public Task<ResultVm> CreateLanguage(RequestLanguageCreateVm req);
          public Task<ResultVm> UpdateLanguage(RequestLanguageUpdateVm req);
          public Task<ResultVm> DeleteLanguage(RequestLanguageDeleteVm req);

        public Task<ViewModels.Layui.TableVm> QueryBulletinPage(RequestBulletinQueryPageVm req);
        public Task<ResultListVm<EntitysModels.System_Bulletin>> QueryBulletinList(RequestBulletinQueryVm req);
        public Task<ResultVm> CreateBulletin(RequestBulletinCreateVm req);
        public Task<ResultVm> UpdateBulletin(RequestBulletinUpdateVm req);
        public Task<ResultVm> DeleteBulletin(RequestBulletinDeleteVm req);
     }
}
