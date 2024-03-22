using FluentValidation;
using FluentValidation.Results;
using TravelAgency.Domain.Common.Exceptions;

namespace TravelAgency.Application.Common; 

public class TravelAgencyAbstractValidator<T> : AbstractValidator<T>
{
    public TravelAgencyAbstractValidator() : base ()
    {}
    public override async Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = default)
    {
        var validationResult = await base.ValidateAsync(context, cancellation);
        if (!validationResult.IsValid)
        {
            string errorMessage = ""; 
            foreach (var item in validationResult.Errors)
            {
                errorMessage += item.ErrorMessage + " "; 
            }
            throw new TravelAgencyException(errorMessage,"Error when validation was attempted",400);
        }
        return validationResult; 
    }
}