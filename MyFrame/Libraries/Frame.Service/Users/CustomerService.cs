using Frame.Core.Domain.Users;
using Frame.Data;
using Frame.Service.Users.Model;
using Frame.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Users
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IDbContext _dbContxt;
        public CustomerService(IRepository<Customer> customerRepository,
            IDbContext dbContxt)
        {
            _customerRepository = customerRepository;
            _dbContxt = dbContxt;
        }
        public Customer Get(int id)
        {
            return _customerRepository.Get(id);
        }


        public int Insert(Customer entity)
        {
            return _customerRepository.Insert(entity);
        }


        public Customer GetCustomer(string email, string password)
        {
            return _customerRepository.Table.FirstOrDefault(x => x.Email == email && x.PassWord == password);
        }



        public Customer GetCustomerByEmail(string email)
        {
            return _customerRepository.Table.FirstOrDefault(x => x.Email == email);
        }


        public IPagedList<CustomerModel> GetModels(CustomerCndModel cnd)
        {
            var query = from a in _customerRepository.Table.Where(x => x.Type != CustomerTypeEnum.SuperAdmin)
                        select new CustomerModel
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Email = a.Email,
                            Active = a.Active,
                            Type = a.Type,
                            CreatedTime = a.CreatedTime
                        };
            if (cnd.Id > 0)
            {
                query = query.Where(x => x.Id == cnd.Id);
            }
            if (!string.IsNullOrEmpty(cnd.Name))
            {
                query = query.Where(x => x.Name == cnd.Name.Trim());
            }
            if (!string.IsNullOrEmpty(cnd.Email))
            {
                query = query.Where(x => x.Email == cnd.Email.Trim());
            }
            if (cnd.Active.HasValue)
            {
                query = query.Where(x => x.Active == cnd.Active.Value);
            }
            if (cnd.Type.HasValue)
            {
                query = query.Where(x => x.Type == cnd.Type.Value);
            }
            if (cnd.Start.HasValue)
            {
                var start = cnd.Start.Value.Date;
                query = query.Where(x => x.CreatedTime >= start);

            }
            if (cnd.End.HasValue)
            {
                query = query.Where(x => x.CreatedTime <= cnd.End.Value);
            }
            return new PagedList<CustomerModel>(query = query.OrderByDescending(x => x.Id), cnd.PageIndex, cnd.PageSize);
        }

        public bool AddOrUpdate(CustomerModel model)
        {
            if (model.Id > 0)
            {
                var entity = _customerRepository.Table.FirstOrDefault(x => x.Id == model.Id);
                entity.Name = model.Name;
                entity.ModifyTime = DateTime.Now;
                entity.Active = model.Active;
                return _customerRepository.Update(entity) > 0;
            }
            else
            {
                var entity = new Customer
                {
                    Name = model.Name,
                    Email = model.Email,
                    CreatedTime = DateTime.Now,
                    Active = model.Active,
                    Type = model.Type,
                    ParentId = model.ParentId,
                    PassWord = SignUtil.MD5Sign(model.PassWord)
                };
                return _customerRepository.Insert(entity) > 0;
            }
        }

        public bool Delete(List<int> ids)
        {
            return _customerRepository.Delete(x => ids.Contains(x.Id)) > 0;
        }


        public CustomerModel GetModel(int id)
        {
            var query = from a in _customerRepository.Table.Where(x => x.Id == id)
                        select new CustomerModel
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Email = a.Email,
                            Active = a.Active,
                            Type = a.Type,
                            CreatedTime = a.CreatedTime
                        };
            return query.FirstOrDefault();
        }


        public bool ExistName(string name, int id)
        {
            return _customerRepository.Table.Any(x => x.Name == name && x.Id != id);
        }

        public bool ExistEamil(string email, int id)
        {
            return _customerRepository.Table.Any(x => x.Email == email && x.Id != id);
        }


        public bool Grant(int id, List<int> roleIds)
        {
            var customer = _dbContxt.Set<Customer>().Find(id);
            var roles = _dbContxt.Set<Role>().Where(x => roleIds.Contains(x.Id));

            //添加新权限
            roles.ToList().ForEach(x =>
            {
                if (!customer.Roles.Any(y => y.Id == x.Id))
                {
                    customer.Roles.Add(x);
                }
            });

            //删除权限
            customer.Roles.OrderBy(x => x.Id).ToList().ForEach(x =>
            {
                if (!roles.Any(y => y.Id == x.Id))
                {
                    customer.Roles.Remove(x);
                }
            });
            _dbContxt.SaveChangesAsync();
            return true;
        }
    }
}
