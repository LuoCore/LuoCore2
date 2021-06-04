using DataTransferModels.CreateEntity.Request;
using IRepository;
using IServices;
using System;
using System.Threading.Tasks;
using Utility.Factory;
using ViewModels.SystemBase.Request;

namespace Services
{
    public class CreateEntityService : BaseService<ICreateEntityRepository>, ICreateEntityService
    {
        public CreateEntityService(ISqlSugarFactory factory, ISystemLogsRepository logsRepository, ICreateEntityRepository repository) : base(factory, logsRepository, repository)
        {
        }

        public Task<bool> CreateDefaultValue(CreateEntityVm req) 
        {
            return Task.FromResult(DbRepository.CreateDefaultValue(new CreateEntityDto() { DirectoryPath = req.DirectoryPath, NameSpace = req.NameSpace }));
        }

        public Task<bool> CreateAttribute(CreateEntityVm req)
        {
            return Task.FromResult(DbRepository.CreateAttribute(new CreateEntityDto() { DirectoryPath = req.DirectoryPath, NameSpace = req.NameSpace }));
        }
    }
}
