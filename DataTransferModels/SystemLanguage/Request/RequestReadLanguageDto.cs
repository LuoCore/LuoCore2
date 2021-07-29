using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLanguage.Request
{
     public class RequestReadLanguageDto
     {
          public RequestReadLanguageDto(int languageID, string languageName,string languageJson, bool? isValid)
          {
            LanguageID = languageID;
               LanguageName = languageName;
               LanguageJson = languageJson;
               IsValid = isValid;
              
          }

          public int LanguageID { get; protected set; }
          public string LanguageName { get; protected set; }
          public string LanguageJson { get; protected set; }
          public bool? IsValid { get; protected set; }
     }
}
