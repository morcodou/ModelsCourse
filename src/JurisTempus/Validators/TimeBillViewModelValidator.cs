using FluentValidation;
using JurisTempus.Data.Entities;
using JurisTempus.ViewModels;

namespace JurisTempus.Validators
{
  public class TimeBillViewModelValidator : AbstractValidator<TimeBillViewModel>
  {
    public TimeBillViewModelValidator()
    {
      //RuleFor(c => c.FileNumber).NotEmpty()
      //                          .Matches(@"^\d{10}")
      //                          .WithMessage("File Number must be ten digits");

      //RuleFor(c => c.Status).IsInEnum()
      //                      .NotEqual(CaseStatus.Invalid)
      //                      .WithName("CaseStatus");

    }
  }
}
