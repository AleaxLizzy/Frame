using Frame.Core.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core.Domain.Users
{
    public class Role : BaseEntity
    {
        public Role()
        {
            Permissions = new List<Permission>();

        }
        public string Name { get; set; }

        public string SystemName { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }

        public int? ParentId { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

        public RoleTypeEnum Type { get; set; }
    }

    public enum RoleTypeEnum
    {
        /// <summary>
        /// 管理员后台超级管理员角色
        /// </summary>
        SuperAdminRole = 0,

        /// <summary>
        /// 管理员后台普通管理员角色
        /// </summary>
        AdminRole = 1,

        /// <summary>
        ///业务系统普通角色
        /// </summary>
        NormalRole = 2
    }
}
