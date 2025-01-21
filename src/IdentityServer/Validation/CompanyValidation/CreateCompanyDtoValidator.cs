using System;
using System.Text.RegularExpressions;
using FluentValidation;

public class CreateCompanyDtoValidator : AbstractValidator<CreateCompanyDto>
{
    public CreateCompanyDtoValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("Company name cannot be empty.")
            .MaximumLength(200).WithMessage("Company name can be at most 200 characters.")
            .Must(ValidateSqlInjection).WithMessage("Company name contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Company name contains invalid characters.");

        RuleFor(x => x.TaxNumber)
            .NotEmpty().WithMessage("Tax number cannot be empty.")
            .MinimumLength(10).WithMessage("Tax number must be at least 10 characters.")
            .MaximumLength(11).WithMessage("Tax number can be at most 11 characters.")
            .Matches("^[0-9]+$").WithMessage("Tax number must consist only of numbers.")
            .Must(ValidateSqlInjection).WithMessage("Tax number contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Tax number contains invalid characters.");

        RuleFor(x => x.TradeRegistryNumber)
            .NotEmpty().WithMessage("Trade registry number cannot be empty.")
            .MaximumLength(50).WithMessage("Trade registry number can be at most 50 characters.")
            .Must(ValidateSqlInjection).WithMessage("Trade registry number contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Trade registry number contains invalid characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description can be at most 500 characters.")
            .Must(ValidateSqlInjection).WithMessage("Description contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Description contains invalid characters.");

        RuleFor(x => x.Address)
            .MaximumLength(300).WithMessage("Address can be at most 300 characters.")
            .Must(ValidateSqlInjection).WithMessage("Address contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Address contains invalid characters.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City cannot be empty.")
            .MaximumLength(100).WithMessage("City can be at most 100 characters.")
            .Must(ValidateSqlInjection).WithMessage("City contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("City contains invalid characters.");

        RuleFor(x => x.District)
            .NotEmpty().WithMessage("District cannot be empty.")
            .MaximumLength(100).WithMessage("District can be at most 100 characters.")
            .Must(ValidateSqlInjection).WithMessage("District contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("District contains invalid characters.");
            
        RuleFor(x => x.PostalCode)
            .MaximumLength(5).WithMessage("Postal code can be at most 5 characters.")
            .Matches("^[0-9]*$").WithMessage("Postal code must consist only of numbers.")
            .Must(ValidateSqlInjection).WithMessage("Postal code contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Postal code contains invalid characters.");

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(13).WithMessage("Phone number can be at most 13 characters.")
            .Matches(@"^\+?[0-9]*$").WithMessage("Phone number is invalid.")
            .Must(ValidateSqlInjection).WithMessage("Phone number contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Phone number contains invalid characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address cannot be empty.")
            .EmailAddress().WithMessage("Please enter a valid email address.")
            .MaximumLength(200).WithMessage("Email address can be at most 200 characters.")
            .Must(ValidateSqlInjection).WithMessage("Email address contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Email address contains invalid characters.");

        RuleFor(x => x.WebsiteUrl)
            .MaximumLength(200).WithMessage("Website address can be at most 200 characters.")
            .Matches(@"^(https?://)?(www\.)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,}(/.*)?$").WithMessage("Please enter a valid website address.")
            .When(x => !string.IsNullOrWhiteSpace(x.WebsiteUrl))
            .Must(ValidateSqlInjection).WithMessage("Website contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Website contains invalid characters.");

        RuleFor(x => x.CompanyManager)
            .MaximumLength(200).WithMessage("Company manager name can be at most 200 characters.")
            .Must(ValidateSqlInjection).WithMessage("Company manager contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Company manager contains invalid characters.");

        RuleFor(x => x.IndustryType)
            .MaximumLength(100).WithMessage("Industry type can be at most 100 characters.")
            .Must(ValidateSqlInjection).WithMessage("Industry type contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Industry type contains invalid characters.");

        RuleFor(x => x.LegalRepresentative)
            .MaximumLength(200).WithMessage("Legal representative name can be at most 200 characters.")
            .Must(ValidateSqlInjection).WithMessage("Legal representative contains invalid characters.")
            .Must(ValidateJsInjection).WithMessage("Legal representative contains invalid characters.");

        RuleFor(x => x.EstablishedDate)
            .NotEmpty().WithMessage("Establishment date cannot be empty.")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("Establishment date cannot be later than today.");

        RuleFor(x => x.IsTaxpayer)
            .NotNull().WithMessage("Taxpayer status must be specified.");

        RuleFor(x => x.IsRegisteredForVAT)
            .NotNull().WithMessage("VAT registration status must be specified.");
    }

    private bool ValidateSqlInjection(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return true;

        string pattern = @"(\b(SELECT|INSERT|UPDATE|DELETE|DROP|TRUNCATE|REPLACE|UNION|AND|OR|--|#|/\*|\*/|;)|
                          (xp_)|(\bEXEC\b)|(\bSLEEP\b)|(\bWAITFOR\b)|(\bDECLARE\b)|(\bDECLARE\b))";

        return !Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }

    private bool ValidateJsInjection(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return true;

        string jsPattern = @"(<script.*?>.*?</script>)|(<.*?on\w+=.*?>)|(<.*?javascript:.*?>)|(<.*?src=.*?javascript:.*?>)|
                            (<.*?data.*?=.*?javascript:.*?>)|(<.*?img.*?onerror=.*?>)|(<.*?iframe.*?src=.*?>)|(<.*?eval\(.*\)>|
                            <.*?alert\(.*\))|(<.*?document\.cookie)|(<.*?document\.write)|(<.*?window\.location)|<.*?window\.open|<.*?onmouseover";

        return !Regex.IsMatch(input, jsPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }
}
