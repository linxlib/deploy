using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    /// <summary>
    /// 向agent下发部署消息
    /// </summary>
    public class DeployMessage
    {
        /// <summary>
        /// 要部署的服务ID
        /// </summary>
        public string ServiceId { get; set; }
        /// <summary>
        /// 压缩包
        /// </summary>
        public string DownloadFileID { get; set; }
        /// <summary>
        /// 文件hash
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long Size { get; set; }
    }

    public class RollbackMessage
    {
        public string ServiceId { get; set; }
        public string Version { get; set; }
    }

    public class NormalMessage
    {
    }
}
