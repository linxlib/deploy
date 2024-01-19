using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entity
{
    public enum FileType
    {
        /// <summary>
        /// 安装包
        /// </summary>
        Setup,
        /// <summary>
        /// 更新包
        /// </summary>
        Update,
        /// <summary>
        /// 头像
        /// </summary>
        Avatar,

    }
    public class ResourceFile:BaseEntity
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FileType FileType { get; set; }
        /// <summary>
        /// 自定义的文件ID
        /// </summary>
        public string FileKey { get; set; }
        /// <summary>
        /// LiteDB的文件存储Key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime InDate { get; set; }

    }
}
