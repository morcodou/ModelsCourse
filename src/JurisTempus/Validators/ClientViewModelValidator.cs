using FluentValidation;
using JurisTempus.Data.Entities;
using JurisTempus.ViewModels;

namespace JurisTempus.Validators
{
  public class ClientViewModelValidator : AbstractValidator<ClientViewModel>
  {
    public ClientViewModelValidator()
    {
      RuleFor(c => c.Name).NotEmpty()
                                .MinimumLength(5)
                                .MaximumLength(100);

      RuleFor(c => c.ContactName).MaximumLength(50);

      When(c => !string.IsNullOrEmpty(c.Phone) ||
                !string.IsNullOrEmpty(c.ContactName),
      () =>
      {
        RuleFor(c => c.Phone).NotEmpty()
                             .WithMessage("Phone cannot be empty, if contact is specify");
        RuleFor(c => c.ContactName).NotEmpty()
                             .WithMessage("Contact name cannot be empty, if phone is specify");
      });
    }
  }
}
