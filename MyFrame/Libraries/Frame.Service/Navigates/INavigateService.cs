using Frame.Core.Domain.Navigates;
using Frame.Service.Models.Navitages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Navigates
{
    public interface INavigateService
    {

        IList<NavigateModel> GetPermissionModels();

        IList<NavigateModel> GetModelByCnd(NavigateCndModel cnd);
    }
}
