using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{

    public class Version: BaseEntity
    {
        /// <summary>
        /// 版本号
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 版本号数
        /// </summary>
        public int VersionInt { get; set; }
        /// <summary>
        /// 版本时间
        /// </summary>
        public DateTime InDate { get; set; }
        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 下载时的ID
        /// </summary>
        public string DownloadID { get; set; }
        /// <summary>
        /// 更新包哈希
        /// </summary>

        public string Hash { get; set; }
        /// <summary>
        /// 更新包大小
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish { get; set; }
        /// <summary>
        /// 更新日志
        /// </summary>
        public string ReleaseLog { get; set; }

        public DateTime  PublishTime { get; set; }


    }
}
