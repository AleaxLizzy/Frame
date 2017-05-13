using Frame.Core.Domain.Users;
using Frame.Data;
using Frame.Service.Users.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Users
{
    public interface ICustomerService
    {
        Customer Get(int id);

        Customer GetCustomerByEmail(string email);

        int Insert(Customer entity);

        Customer GetCustomer(string email,string password);

        IPagedList<CustomerModel> GetModels(CustomerCndModel cnd);

        CustomerModel GetModel(int id);

        bool AddOrUpdate(CustomerModel model);

        bool Delete(List<int> ids);

        bool ExistName(string name, int id);

        bool ExistEamil(string email, int id);

        bool Grant(int id,List<int> roleIds);
    }
}
