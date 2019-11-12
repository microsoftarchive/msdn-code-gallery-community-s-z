using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR1V1Chat.Models
{
    /// <summary>
    /// 用户信息实体
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 连接ID
        /// </summary>
        public string ConnectionId { get; set; }

        public string UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
    }
}