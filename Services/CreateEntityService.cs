using IRepository;
using IServices;
using System;
using System.Threading.Tasks;
using Utility.Factory;
using ViewModels.Request;

namespace Services
{
    public class CreateEntityService : BaseService<ICreateEntityRepository>, ICreateEntityService
    {
        public CreateEntityService(ISqlSugarFactory factory, ISystemLogsRepository logsRepository, ICreateEntityRepository repository) : base(factory, logsRepository, repository)
        {
        }

        public Task<bool> CreateDefaultValue(CreateEntityVm.CreateDefaultValue req) 
        {
            return Task.FromResult(DbRepository.CreateDefaultValue(new DataTransferModels.Request.CreateEntityDto.CreateDefaultValue() { DirectoryPath = req.DirectoryPath, NnameSpace = req.NameSpace }));
        }

        public Task<bool> CreateAttribute(CreateEntityVm.CreateDefaultValue req)
        {
            return Task.FromResult(DbRepository.CreateAttribute(new DataTransferModels.Request.CreateEntityDto.CreateDefaultValue() { DirectoryPath = req.DirectoryPath, NnameSpace = req.NameSpace }));
        }
    }
}
