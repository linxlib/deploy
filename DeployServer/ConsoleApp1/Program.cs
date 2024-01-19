using Ext;
using Microsoft.Web.Administration;
using System.Drawing;
using System.IO.Compression;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var fs = new FileStream("win-x64.zip",FileMode.Open))
            {
                var a = new ZipArchive(fs,ZipArchiveMode.Read,false,Encoding.GetEncoding("GB2312"));
                a.ExtractToDirectory(AppDomain.CurrentDomain.BaseDirectory,true);
            }
                Console.ReadLine();
        }
    }
}