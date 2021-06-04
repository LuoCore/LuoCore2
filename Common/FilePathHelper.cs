using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FilePathHelper
    {

        private static void TestGetFilePaht()
        {




            string rootPath = "";
            string BaseDirectoryPath = Environment.CurrentDirectory;
            rootPath = BaseDirectoryPath.Substring(0, BaseDirectoryPath.LastIndexOf("\\"));
            // F:\project\WPF\AstroATE-PDR\04. 程序\01. 源代码\AstroATE\AstroATE\bin\Debug
            // 向上回退三级，得到需要的目录
            // 第一个\是转义符，所以要写两个
            rootPath = rootPath.Substring(0, rootPath.LastIndexOf(@"\"));   // 或者写成这种格式
            rootPath = rootPath.Substring(0, rootPath.LastIndexOf("\\")); // @"F:\project\WPF\AstroATE-PDR\04. 程序\01. 源代码\AstroATE\AstroATE




            string str = Environment.NewLine;
            string str2 = Environment.CommandLine;
            string str3 = Environment.CurrentDirectory;
            string str4 = Environment.MachineName;
            string str5 = Environment.UserName;
            string str6 = Environment.UserDomainName;
            var str7 = Environment.OSVersion;
            var str8 = Environment.CurrentManagedThreadId;
            var str9 = Environment.ExitCode;
            var str10 = Environment.Version;
            string str11 = Environment.StackTrace;
            string str12 = Environment.SystemDirectory;
            var ddd = System.Threading.Thread.GetDomain().BaseDirectory;
            System.Reflection.Assembly curPath = System.Reflection.Assembly.GetExecutingAssembly();
            string path = curPath.Location;
            System.Diagnostics.StackFrame f = new System.Diagnostics.StackFrame(1);
            var mb = f.GetMethod();
            var v1 = AppDomain.CurrentDomain.BaseDirectory;
            var v2 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        }


        public static string GetCurrentProjectRootPath
        {
            get
            {
                string BaseDirectoryPath = Environment.CurrentDirectory;
                string rootPath = BaseDirectoryPath.Substring(0, BaseDirectoryPath.LastIndexOf("\\"));
                return rootPath;
            }

        }


        public static string GetCurrentProjectPath
        {
            get
            {
                return Environment.CurrentDirectory;
            }

        }
    }
}
