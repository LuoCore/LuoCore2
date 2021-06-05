using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Layui
{
    public class TableVm
    {
        /// <summary>
        /// 接口状态
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 提示文本
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 数据列表
        /// </summary>
        public dynamic data { get; set; }
    }
}
