using FluentValidation;
using Frame.Service.Models.Role;
using Frame.Service.Users.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frame.Admin.Validator.ValidatorModels
{
    public class CustomerModelValidator : AbstractValidator<CustomerModel>
    {
        public CustomerModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("用户名不能为空").Length(1, 10).WithMessage("长度在1-10之间");
            RuleFor(x => x.Email).NotNull().WithMessage("邮箱不能为空").EmailAddress().WithMessage("请输入正确的邮箱地址");
            RuleFor(x => x.PassWord).NotNull().WithMessage("密码不能为空").Length(8, 16).WithMessage("长度在8-16之间");
            RuleFor(x => x.PassWordConfirm).NotNull().WithMessage("密码不能为空").Equal(y => y.PassWord).WithMessage("密码输入必须一致");
        }
    }
}