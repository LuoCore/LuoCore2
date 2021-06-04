using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.CreateEntity.Request
{
    public class CreateEntityDto
    {
        public string DirectoryPath { get; set; }
        public string NameSpace { get; set; }

    }
}
