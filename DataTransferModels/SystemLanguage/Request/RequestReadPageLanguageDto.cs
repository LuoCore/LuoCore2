using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLanguage.Request
{
     public class RequestReadPageLanguageDto:RequestReadLanguageDto
    {
        public RequestReadPageLanguageDto(int iD, string languageName, string languageJson, bool? isValid,int pageIndex,int pageSize) : base(iD, languageName, languageJson, isValid)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }

        public int PageIndex { get; protected set; }
          public int PageSize { get; protected set; }
     }
}
