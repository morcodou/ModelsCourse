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
    }
  }
}
