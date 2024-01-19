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
