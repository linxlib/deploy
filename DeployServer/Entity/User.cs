using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public bool Enable { get; set; }
        /// <summary>
        /// 加入时间
        /// </summary>
        public DateTime InDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime EditDate { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
