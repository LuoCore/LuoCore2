using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class ImageHelper
    {
        public static async Task<string> UpLoadImage(string filePath, Microsoft.AspNetCore.Http.IFormFile formFile)
        {
            try
            {
                var str_directory = @"images//wangEditorImage//" + DateTime.Now.ToString("yyyyMMdd");
                if (!Directory.Exists(filePath + @"//" + str_directory))//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(filePath + @"//" + str_directory);
                }

                var fileName = DateTime.Now.ToString("HHmmssfff") + Path.GetExtension(formFile.FileName);
                var path = Path.Combine(filePath + @"//" + str_directory, fileName);
                using (var stream = new FileStream(path, FileMode.CreateNew))
                {
                    await formFile.CopyToAsync(stream);
                }
                return str_directory + @"//" + fileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return string.Empty;
            }

        }
    }
}
