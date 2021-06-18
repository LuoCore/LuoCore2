using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataTransferModels.BaseUser.Response
{
    public class ResponseUserPageDto
    {
        public ResponseUserPageDto(List<Base_User> pageList, int pageCount)
        {
            PageList = pageList;
            PageCount = pageCount;
        }

        public List<EntitysModels.Base_User> PageList { get;protected set; }
        public int PageCount { get; protected set; }
    }
}
