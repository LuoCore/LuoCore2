using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLanguage.Request
{
     public class RequestCreateLanguageDto: RequestBaseDto
     {
          public RequestCreateLanguageDto(string languageName, string languageJson, bool isValid,string actionUserInfo, string actionUserName) : base(actionUserName, actionUserInfo)
        {
               LanguageName = languageName;
               LanguageJson = languageJson;
               IsValid = isValid;
          }

          public string LanguageName { get;protected  set; }
          public string LanguageJson { get; protected set; }
          public bool IsValid { get; protected set; }
     }
}
