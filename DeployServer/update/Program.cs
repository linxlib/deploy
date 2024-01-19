using Ext;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;

namespace update
{
    internal class Program
    {
        static async Task doUpdate(string[] args)
        {
            var pid = args[0];
            var exe = args[1];
            var url = args[2];

            await Console.Out.WriteLineAsync($"等待进程退出[{pid}]....");
            await Console.Out.WriteLineAsync("下载更新包...");
            await Console.Out.WriteLineAsync($"下载更新包{url}");
            var client = new HttpClient();
            var filePath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "tmp");
            Directory.CreateDirectory(filePath);

            //client.BaseAddress = new Uri(url);
            var stream = await client.GetAsync(url);
            var proc = Process.GetProcessById(Convert.ToInt32(pid));
            if (proc != null)
            {
                proc.Kill();
            }
            await Console.Out.WriteLineAsync("进程已经退出, 开始更新");
            await Console.Out.WriteLineAsync($"解压到{filePath}");
            using (var ms = new MemoryStream())
            {
                await stream.Content.CopyToAsync(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var zip = new ZipArchive(ms,ZipArchiveMode.Read,false,Encoding.GetEncoding("GB2312"));
                zip.ExtractToDirectory(filePath, true);
            //    ms.UnZip(filePath);
            }
      

            ServiceExtensions.CopyDir(filePath, AppDomain.CurrentDomain.BaseDirectory);
            await Console.Out.WriteLineAsync("更新完成, 启动程序");
            Directory.Delete(filePath, true);
            var p = new Process();
            p.StartInfo.FileName = Path.Join(AppDomain.CurrentDomain.BaseDirectory + $"/{exe}");
            p.StartInfo.UseShellExecute = true;
            p.Start();
        }
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            doUpdate(args).Wait() ;
            //Console.ReadLine();
        }
    }
}