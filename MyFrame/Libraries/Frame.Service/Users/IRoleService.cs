using Frame.Core.Domain.Users;
using Frame.Data;
using Frame.Service.Models.Role;
using Frame.Service.Models.Role.CndModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Users
{
    public interface IRoleService
    {

        bool ExistName(string name, int id);

        bool ExisSystemName(string name, int id);
        Role GetSuperRole();

        RoleModel GetModel(int id);
        Role GetRoleBySystemName(string systemName);

        Role GetRole(int id);

        IPagedList<RoleModel> GetRoles(RoleCndModel cnd);

        int Delete(List<int> ids);

        int AddOrUpdate(RoleModel model);

        bool Update(int id, List<int> permissionIds);

        IList<Role> Roles(RoleTypeEnum type = RoleTypeEnum.AdminRole);
    }
}
