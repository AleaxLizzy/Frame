using FluentValidation;
using Frame.Service.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frame.Admin.Validator.ValidatorModels
{
    public class RoleModelValidator : AbstractValidator<RoleModel>
    {
        public RoleModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("用户名不能为空").Length(1, 10).WithMessage("长度不能大于10");
            RuleFor(x => x.SystemName).NotNull().WithMessage("不能为空").Length(1,10).WithMessage("长度不能大于10");
            RuleFor(x => x.Type).NotNull().WithMessage("不能为空");
        }
    }
}