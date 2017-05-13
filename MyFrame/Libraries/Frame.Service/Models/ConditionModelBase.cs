using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Models
{
    public class ConditionModelBase
    {
        public ConditionModelBase()
        {
            PageIndex = 0;
            PageSize = 1;
        }
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
    }
}
