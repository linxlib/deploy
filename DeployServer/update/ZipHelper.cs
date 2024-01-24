using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Ext
{
    public sealed class ZipHelper
    {
        public static bool CopyDir(string srcPath, string destPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)     //判断是否文件夹
                    {

                        if (!Directory.Exists(Path.Join(destPath, i.Name)))
                        {
                            Directory.CreateDirectory(Path.Join(destPath, i.Name));   //目标目录下不存在此文件夹即创建子文件夹
                        }
                        CopyDir(i.FullName, Path.Join(destPath, i.Name));    //递归调用复制子文件夹
                    }
                    else
                    {
                        File.Copy(i.FullName, Path.Join(destPath, i.Name), true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "  " + ex.StackTrace);
                return false;
            }
        }
        /// <summary>
        /// 忽略的文件
        /// </summary>

        private List<string> excludeNames = new List<string>
        {
           "appsettings.json",
           "appsettings.Development.json",
           "appsettings.Production.json",
           "appsettings.Staging.json",
           "config.json",
           "config.ini",
           "config.yaml",
           "config.yml",
           "config.toml"
        };
        public ZipHelper(List<string> ignoredFiles)
        {
            excludeNames = ignoredFiles;
        }
        public ZipHelper()
        {
            
        }
        /// <summary>
        /// 目录压缩为zip
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="zipFile"></param>
        public Task CreateZipFromDirectory(string directory, string zipFile)
        {
            return Task.Run(() =>
            {
                using (FileStream fileStream = new FileStream(zipFile, FileMode.OpenOrCreate))
                {
                    using (ZipArchive archive = new ZipArchive(fileStream, ZipArchiveMode.Create, false))
                    {
                        AddDirectoryToArchive("", directory, archive);
                    }

                }
            });
           
        }
        /// <summary>
        /// 多个文件压缩为zip
        /// </summary>
        /// <param name="files"></param>
        /// <param name="zipFile"></param>
        public Task CreateZipFromFiles(List<string> files,string zipFile)
        {
            return Task.Run(() =>
            {
                using (FileStream fileStream = new FileStream(zipFile, FileMode.OpenOrCreate))
                {
                    using (ZipArchive archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true))
                    {
                        
                        foreach (var item in files)
                        {
                            AddFileToArchive(archive, item, Path.GetFileName(item));
                        }

                    }
                    fileStream.Flush();
                }
            });
          
        }
        private void AddFileToArchive(ZipArchive archive,string file,string fileName)
        {
            var flag = false;
            foreach (var item in excludeNames)
            {
                if (file.Contains(item))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                ZipArchiveEntry entry = archive.CreateEntry(fileName);
                using Stream stream = entry.Open();
                byte[] bytes = File.ReadAllBytes(file);
                stream.Write(bytes, 0, bytes.Length);

            }

        }

        private void AddDirectoryToArchive(
        string directoryBase,
        string directory,
        ZipArchive archive)
        {
            foreach (string file in Directory.GetFiles(directory))
            {
                var flag = false;
                foreach (var item in excludeNames)
                {
                    if (file.Contains(item))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    ZipArchiveEntry entry = archive.CreateEntry(directoryBase + Path.GetFileName(file));
                    using Stream stream = entry.Open();
                    byte[] bytes = File.ReadAllBytes(file);
                    stream.Write(bytes, 0, bytes.Length);
                }
          
            }

            foreach (string subDirectory in Directory.GetDirectories(directory))
            {
                string subDirectoryName = Path.GetFileName(subDirectory);
                if (subDirectoryName == "")
                {
                    continue;
                }

                archive.CreateEntry(directoryBase + subDirectoryName + "/");
                AddDirectoryToArchive(directoryBase + subDirectoryName + "/",
                    subDirectory,
                    archive);
            }
        }




    }

    public static class ZipExtensions
    {
        /// <summary>
        /// 解压流
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="targetDir"></param>
        /// <param name="overwrite"></param>
        public static void UnZip(this Stream stream, string targetDir, bool overwrite = true)
        {

            var zip = new ZipArchive(stream,ZipArchiveMode.Read,false,Encoding.UTF8);
            zip.ExtractToDirectory(targetDir, overwrite);
        }
    }


}
