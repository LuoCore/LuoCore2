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
          public ResultVm CreateLink(RequestLinkCreateVm req);
          public ResultVm UpdateLink(RequestLinkUpdateVm req);
          public ResultVm DeleteLink(RequestLinkDeleteVm req);
     }
}
