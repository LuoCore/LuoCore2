using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLanguage.Request
{
     public class RequestReadLanguageDto
     {
          public RequestReadLanguageDto(int iD, string languageName,string languageJson, bool? isValid)
          {
               ID = iD;
               LanguageName = languageName;
               LanguageJson = languageJson;
               IsValid = isValid;
              
          }

          public int ID { get; protected set; }
          public string LanguageName { get; protected set; }
          public string LanguageJson { get; protected set; }
          public bool? IsValid { get; protected set; }
     }
}
