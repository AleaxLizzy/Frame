using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core.Domain.Permissions
{
    public class Permission : BaseEntity
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        //   public IEnumerable<Permission> Implies { get; set; }
    }
}
