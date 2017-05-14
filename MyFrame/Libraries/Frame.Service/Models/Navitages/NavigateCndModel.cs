using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Models.Navitages
{
    public class NavigateCndModel:ConditionModelBase
    {
        public string Name { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public bool? Active { get; set; }

        public int ParentdId { get; set; }
    }
}
