using Frame.Core.Domain.Navigates;
using Frame.Data;
using Frame.Service.Models.Navitages;
using Frame.Service.Permissions;
using Frame.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Navigates
{
    public class NavigateService : INavigateService
    {
        private readonly IRepository<Navigate> _navigateRepository;
        private readonly IEntityPermissionService _entityPermissionService;
        public NavigateService(IRepository<Navigate> navigateRepository,
            IEntityPermissionService entityPermissionService)
        {
            _navigateRepository = navigateRepository;
            _entityPermissionService = entityPermissionService;
        }



        public IList<NavigateModel> GetPermissionModels()
        {
            var navigates = _navigateRepository.Table.Where(x => x.Active).ToList().Where(x => _entityPermissionService.Authorze<Navigate>(x)).ToList();
            var ids = navigates.Select(x => x.Id).ToList();
            var modelList = new List<NavigateModel>();
            InitNavigate(navigates.Where(x => x.ParentId == null).ToList(), modelList, ids);
            return modelList;
        }

        private void InitNavigate(List<Navigate> navigates, List<NavigateModel> models, List<int> ids)
        {
            if (navigates.Any())
            {
                foreach (var item in navigates)
                {
                    var model = new NavigateModel
                    {
                        Id = item.Id,
                        Action = item.Action,
                        Name = item.Name,
                        Controller = item.Controller,
                        Icon = item.Icon,
                        Sort = item.Sort
                    };
                    models.Add(model);
                    if (item.Childrens.Any())
                    {
                        foreach (var child in item.Childrens.Where(x => ids.Contains(x.Id)).ToList())
                        {
                            var childModel = new NavigateModel
                            {
                                Id = child.Id,
                                Action = child.Action,
                                Name = child.Name,
                                Controller = child.Controller,
                                Icon = child.Icon,
                                Sort = child.Sort
                            };
                            model.Childrens.Add(childModel);
                            if (child.Childrens.Any())
                            {
                                var chids = new List<NavigateModel>();
                                childModel.Childrens = chids;
                                InitNavigate(child.Childrens.Where(x => ids.Contains(x.Id)).ToList(), chids, ids);
                            }
                        }
                    }
                }
            }
        }

        public IList<NavigateModel> GetModelByCnd(NavigateCndModel cnd)
        {
            var query = from a in _navigateRepository.Table.Where(x => x.Active)
                        select new NavigateModel
                        {
                            Id=a.Id,
                            Name=a.Name,
                            Controller=a.Controller,
                            Active=a.Active,
                            Action=a.Action,
                            Sort=a.Sort,
                            CreatedTime=a.CreatedTime,
                            ParentId=a.ParentId
                        };
            if(cnd.ParentdId==0)
            {
                query = query.Where(x => x.ParentId == null);
            }
            if (cnd.ParentdId > 0)
            {
                query = query.Where(x => x.ParentId == cnd.ParentdId);
            }
            return query.ToList();
        }
    }
}
