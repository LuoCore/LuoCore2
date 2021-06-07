using System;
using System.Threading.Tasks;
using ViewModels.SystemBasis.Request;

namespace IServices
{
    public interface ICreateEntityService
    {
        public Task<bool> CreateDefaultValue(RequestCreateEntityVm req);
        public Task<bool> CreateAttribute(RequestCreateEntityVm req);
    }
}
