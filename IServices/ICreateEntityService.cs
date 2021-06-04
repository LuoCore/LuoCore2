using System;
using System.Threading.Tasks;
using ViewModels.SystemBase.Request;

namespace IServices
{
    public interface ICreateEntityService
    {
        public Task<bool> CreateDefaultValue(CreateEntityVm req);
        public Task<bool> CreateAttribute(CreateEntityVm req);
    }
}
