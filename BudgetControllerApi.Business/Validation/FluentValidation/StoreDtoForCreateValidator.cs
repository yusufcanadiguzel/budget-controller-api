using BudgetControllerApi.Shared.Dtos.Store;
using BudgetControllerApi.Shared.MagicStrings;
using FluentValidation;

namespace BudgetControllerApi.Business.Validation.FluentValidation
{
    public class StoreDtoForCreateValidator : AbstractValidator<StoreDtoForManipulation>
    {
        // Store Validation
        public StoreDtoForCreateValidator()
        {
            // Name Rules
            RuleFor(x => x.Name).NotEmpty().WithMessage(MagicStrings.StoreNameNotEmpty);
            RuleFor(x => x.Name).MinimumLength(3).WithMessage(MagicStrings.StoreNameMinLength);

            // Address Rules
            RuleFor(x => x.Address).NotEmpty().WithMessage(MagicStrings.StoreAddressNotEmpty);
            RuleFor(x => x.Address).MaximumLength(250).WithMessage(MagicStrings.StoreAddressMinLength);

            // Tax Number Rules
            RuleFor(x => x.TaxNumber).NotEmpty().WithMessage(MagicStrings.StoreTaxNumberNotEmpty);
            RuleFor(x => x.TaxNumber).Length(10).WithMessage(MagicStrings.StoreTaxNumberLength);
        }
    }
}
