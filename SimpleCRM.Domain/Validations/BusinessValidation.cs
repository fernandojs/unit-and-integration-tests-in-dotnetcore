using FluentValidation;

namespace Simple_CRM.Domain.Validations
{
    public class BusinessValidation : AbstractValidator<Business>
    {
        public BusinessValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
          
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty();
        }

    }
}
