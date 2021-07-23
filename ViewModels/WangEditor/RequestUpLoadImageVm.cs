using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.WangEditor
{
    public class ResponseUpLoadImageVm
    {
        public int Errno { get; set; }

        public List<ImageData> Data { get; set; }
        public class ImageData
        {
            public string Url { get; set; }
            public string Alt { get; set; }
            public string Href { get; set; }
        }
    }
}
