using System;
using System.Threading.Tasks;
using ViewModels.Request;

namespace IServices
{
    public interface ICreateEntityService
    {
        public Task<bool> CreateDefaultValue(CreateEntityVm.CreateDefaultValue req);
        public Task<bool> CreateAttribute(CreateEntityVm.CreateDefaultValue req);
    }
}
