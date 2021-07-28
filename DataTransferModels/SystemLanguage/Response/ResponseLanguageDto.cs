using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLanguage.Response
{
    public class ResponseLanguageDto
    {
        public ResponseLanguageDto(List<System_Language> pageDatas)
        {
            PageDatas = pageDatas;
        }

        public List<EntitysModels.System_Language> PageDatas { get; protected set; }
    }
}
