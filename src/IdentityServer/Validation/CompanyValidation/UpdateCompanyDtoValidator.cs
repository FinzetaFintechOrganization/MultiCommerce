using System;
using System.Text.RegularExpressions;
using FluentValidation;

public class UpdateCompanyDtoValidator : AbstractValidator<UpdateCompanyDto>
{
    public UpdateCompanyDtoValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("Company name cannot be empty.")
            .MaximumLength(200).WithMessage("Company name can be at most 200 characters long.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in company name.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in company name.");

        RuleFor(x => x.TaxNumber)
            .NotEmpty().WithMessage("Tax number cannot be empty.")
            .MinimumLength(10).WithMessage("Tax number must be at least 10 characters long.")
            .MaximumLength(11).WithMessage("Tax number can be at most 11 characters long.")
            .Matches("^[0-9]+$").WithMessage("Tax number must consist of digits only.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in tax number.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in tax number.");

        RuleFor(x => x.TradeRegistryNumber)
            .NotEmpty().WithMessage("Trade registry number cannot be empty.")
            .MaximumLength(50).WithMessage("Trade registry number can be at most 50 characters long.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in trade registry number.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in trade registry number.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description can be at most 500 characters long.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in description.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in description.");

        RuleFor(x => x.Address)
            .MaximumLength(300).WithMessage("Address can be at most 300 characters long.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in address.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in address.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City cannot be empty.")
            .MaximumLength(100).WithMessage("City can be at most 100 characters long.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in city.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in city.");

        RuleFor(x => x.District)
            .NotEmpty().WithMessage("District cannot be empty.")
            .MaximumLength(100).WithMessage("District can be at most 100 characters long.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in district.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in district.");

        RuleFor(x => x.PostalCode)
            .MaximumLength(5).WithMessage("Postal code can be at most 5 characters long.")
            .Matches("^[0-9]*$").WithMessage("Postal code must consist of digits only.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in postal code.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in postal code.");

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(13).WithMessage("Phone number can be at most 13 characters long.")
            .Matches(@"^\+?[0-9]*$").WithMessage("Phone number is invalid.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in phone number.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in phone number.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address cannot be empty.")
            .EmailAddress().WithMessage("Please enter a valid email address.")
            .MaximumLength(200).WithMessage("Email address can be at most 200 characters long.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in email address.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in email address.");

        RuleFor(x => x.WebsiteUrl)
            .MaximumLength(200).WithMessage("Website URL can be at most 200 characters long.")
            .Matches(@"^(https?://)?(www\.)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,}(/.*)?$").WithMessage("Please enter a valid website URL.")
            .When(x => !string.IsNullOrWhiteSpace(x.WebsiteUrl))
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in website URL.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in website URL.");

        RuleFor(x => x.CompanyManager)
            .MaximumLength(200).WithMessage("Company manager name can be at most 200 characters long.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in company manager name.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in company manager name.");

        RuleFor(x => x.IndustryType)
            .MaximumLength(100).WithMessage("Industry type can be at most 100 characters long.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in industry type.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in industry type.");

        RuleFor(x => x.LegalRepresentative)
            .MaximumLength(200).WithMessage("Legal representative name can be at most 200 characters long.")
            .Must(input => ValidateSqlInjection(input)).WithMessage("Invalid input detected in legal representative name.")
            .Must(input => ValidateJsInjection(input)).WithMessage("Invalid input detected in legal representative name.");

        RuleFor(x => x.EstablishedDate)
            .NotEmpty().WithMessage("Establishment date cannot be empty.")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("Establishment date cannot be later than today.");

        RuleFor(x => x.IsTaxpayer)
            .NotNull().WithMessage("Taxpayer status must be specified.");

        RuleFor(x => x.IsRegisteredForVAT)
            .NotNull().WithMessage("VAT registration status must be specified.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid status value.");
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
                            <.*?alert\(.*\))|(<.*?document\.cookie)|(<.*?document\.write)|(<.*?window\.location)|<.*?window\.open|<.*?onmouseover)";

        return !Regex.IsMatch(input, jsPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }
}
