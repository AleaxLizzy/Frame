using Frame.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core.Logs
{
    public class Log : BaseEntity
    {
        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 错误级别
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 机器名
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 应用程序区
        /// </summary>
        public string AppDomainName { get; set; }

        /// <summary>
        /// 进程编号
        /// </summary>
        public string ProcessId { get; set; }

        /// <summary>
        /// 进程名称
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 线程编号
        /// </summary>
        public string ThreadId { get; set; }

        /// <summary>
        /// 消息 
        /// </summary>
        public string  Message { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        public string  FormattedMessage { get; set; }

    }
}
