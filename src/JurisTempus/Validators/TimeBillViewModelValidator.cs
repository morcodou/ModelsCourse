using FluentValidation;
using JurisTempus.Data.Entities;
using JurisTempus.ViewModels;

namespace JurisTempus.Validators
{
  public class TimeBillViewModelValidator : AbstractValidator<TimeBillViewModel>
  {
    public TimeBillViewModelValidator()
    {
      RuleFor(b => b.Rate).InclusiveBetween(0m,500m);
      RuleFor(b => b.TimeSegments).GreaterThan(0);
      RuleFor(b => b.WorkDescription).MinimumLength(25);
      RuleFor(b => b.CaseId).NotEmpty();
      RuleFor(b => b.EmployeeId).NotEmpty();
    }
  }
}
