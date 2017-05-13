using FluentValidation;
using Frame.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Frame.Admin.Validator.ValidatorModels
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("请输入正确的邮箱地址").NotNull().WithMessage("请输入用户名");
            RuleFor(x => x.PassWord).NotNull().WithMessage("请输入密码");
        }
     
    }
}