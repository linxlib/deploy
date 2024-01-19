using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext
{
    public class DirectoryFetch
    {
        /// <summary>
        /// 列出路径下的所有文件和目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<PathItem> ListAll(string path)
        {
            var list = new List<PathItem>();
            DirectoryInfo root = new DirectoryInfo(path);
            var items = root.GetFileSystemInfos("*",new EnumerationOptions
            {
                AttributesToSkip = FileAttributes.Hidden|FileAttributes.ReadOnly|FileAttributes.System|FileAttributes.Encrypted
            });
            foreach (var item in items)
            {
                var child = new PathItem
                {
                    Text = item.Name,
                    FullPath = item.FullName,
                    PathType = item.Attributes.HasFlag(FileAttributes.Directory) ? ItemType.Directory : ItemType.File,
                };
                list.Add(child);
            }
            
            return list;
        }
    }
}
