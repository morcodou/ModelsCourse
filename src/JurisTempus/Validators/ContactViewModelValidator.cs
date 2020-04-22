using FluentValidation;
using JurisTempus.Data;
using JurisTempus.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace JurisTempus.Validators
{
  public class ClientViewModelValidator : AbstractValidator<ClientViewModel>
  {
    public ClientViewModelValidator(BillingContext context)
    {
      RuleFor(c => c.Name).NotEmpty()
                                .MinimumLength(5)
                                .MaximumLength(100)
                                .MustAsync(async (value, cancelToken) =>
                                {
                                  return !(await context.Clients.AnyAsync(c => c.Name == value));
                                })
                                .WithMessage("Name must be unique");

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
