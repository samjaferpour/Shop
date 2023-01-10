using FluentValidation;
using Shop.Contract.Dtos;

namespace Shop.Api.Validations
{
    public class CategoryRequestValidator : AbstractValidator<CategoryRequest>
    {
        public CategoryRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("مقدار null ممنوع است");
            RuleFor(c => c.Name).NotEmpty().WithMessage("وارد کردن نام کتگوری الزامی است");
            RuleFor(c => c.Name).MinimumLength(3).WithMessage("ورودی باید بیبشتر از 3 کاراکتر باشد");
        }
    }
}
