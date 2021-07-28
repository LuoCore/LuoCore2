using DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
    public interface ISystemLanguageRepository : ISqlSugarRepository
     {
          public ResultDto<DataTransferModels.SystemLanguage.Response.ResponseLanguagePageDto> ReadLanguagePage(DataTransferModels.SystemLanguage.Request.RequestReadPageLanguageDto req);
        public ResultDto<DataTransferModels.SystemLanguage.Response.ResponseLanguageDto> ReadLanguageList(DataTransferModels.SystemLanguage.Request.RequestReadLanguageDto req);
          public ResultDto Create(DataTransferModels.SystemLanguage.Request.RequestCreateLanguageDto req);
          public ResultDto Update(DataTransferModels.SystemLanguage.Request.RequestUpdateLanguageDto req);
          public ResultDto Delete(DataTransferModels.SystemLanguage.Request.RequestDeleteLanguageDto req);
     }
}
