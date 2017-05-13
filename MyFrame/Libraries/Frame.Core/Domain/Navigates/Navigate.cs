using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Core.Domain.Navigates
{
    public class Navigate : BaseEntity
    {
        public Navigate()
        {
            Childrens = new List<Navigate>();
        }
        public string Controller { get; set; }
        public string Action { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int? ParentId { get; set; }

        public Navigate Parent { get; set; }

        public bool Active { get; set; }

        public int? Sort { get; set; }

        public virtual ICollection<Navigate> Childrens { get; set; }
    }
}
