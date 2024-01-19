using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class DeployDetail
    {
        /// <summary>
        /// 服务类型
        /// </summary>
        public string ServiceType { get; set; }
        /// <summary>
        /// 服务路径
        /// </summary>
        public string ServicePath { get; set; }
        /// <summary>
        /// 版本路径
        /// </summary>
        public string VersionPath { get; set; }
        /// <summary>
        /// 已有版本备份位置
        /// </summary>
        public string PrevVersionPath { get; set; }

    }
    public class DeployTask: BaseEntity
    {

        public DateTime TaskTime { get; set; }
        public string ServerId { get; set; }
        public string ServiceId { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastDeployTime { get; set; }
        public bool LastOK { get; set; }
        public DeployDetail Detail { get; set; }
        /// <summary>
        /// 当前版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 上个版本
        /// </summary>
        public string PrevVersion { get; set; }
        /// <summary>
        /// 部署时需要忽略的文件或者文件夹
        /// </summary>
        public List<string> Excludes { get; set; }



    }
}
