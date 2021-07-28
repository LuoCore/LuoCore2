using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLanguage.Response
{
     public class ResponseLanguagePageDto:ResponseLanguageDto
     {
        public ResponseLanguagePageDto(List<System_Language> pageDatas, int pageCount) : base(pageDatas)
        {
            this.PageCount = pageCount;
        }

        public int PageCount { get; protected set; }
     }
}
