using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Models.Navitages
{
    public class NavigateModel
    {
        public NavigateModel()
        {
            Childrens = new List<NavigateModel>();
        }
        public int Id { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int? ParentId { get; set; }

        public bool Active { get; set; }

        public int? Sort { get; set; }

        public virtual ICollection<NavigateModel> Childrens { get; set; }
    }
}
