using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using IdentityServer.Data;
using System.Collections.Generic;

public class CompanyService : ICompanyService
{
    private readonly ApplicationDbContext _context;

    public CompanyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CompanyResponseDto> CreateCompanyAsync(CreateCompanyDto model)
    {
        // EstablishedDate ve diğer DateTime alanlarının UTC olarak ayarlandığından emin olun.
        DateTime establishedDate = model.EstablishedDate.Kind == DateTimeKind.Utc
            ? model.EstablishedDate
            : DateTime.SpecifyKind(model.EstablishedDate, DateTimeKind.Utc);

        DateTime createdDate = DateTime.UtcNow; // UTC olarak ayarlanıyor
        DateTime updatedDate = DateTime.UtcNow; // UTC olarak ayarlanıyor

        var company = new Company
        {
            CompanyName = model.CompanyName,
            TaxNumber = model.TaxNumber,
            TradeRegistryNumber = model.TradeRegistryNumber,
            Description = model.Description,
            Address = model.Address,
            City = model.City,
            District = model.District,
            PostalCode = model.PostalCode,
            PhoneNumber = model.PhoneNumber,
            Email = model.Email,
            WebsiteUrl = model.WebsiteUrl,
            CompanyManager = model.CompanyManager,
            IndustryType = model.IndustryType,
            LegalRepresentative = model.LegalRepresentative,
            EstablishedDate = establishedDate,
            IsTaxpayer = model.IsTaxpayer,
            IsRegisteredForVAT = model.IsRegisteredForVAT,
            Status = CompanyStatus.Active,
            CreatedDate = createdDate,
            UpdatedDate = updatedDate
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        return new CompanyResponseDto
        {
            Id = company.Id,
            CompanyName = company.CompanyName,
            TaxNumber = company.TaxNumber,
            TradeRegistryNumber = company.TradeRegistryNumber,
            Description = company.Description,
            Address = company.Address,
            City = company.City,
            District = company.District,
            PostalCode = company.PostalCode,
            PhoneNumber = company.PhoneNumber,
            Email = company.Email,
            WebsiteUrl = company.WebsiteUrl,
            CompanyManager = company.CompanyManager,
            IndustryType = company.IndustryType,
            LegalRepresentative = company.LegalRepresentative,
            EstablishedDate = company.EstablishedDate,
            CreatedDate = company.CreatedDate,
            UpdatedDate = company.UpdatedDate,
            Status = company.Status,
            IsTaxpayer = company.IsTaxpayer,
            IsRegisteredForVAT = company.IsRegisteredForVAT
        };
    }


    public async Task<CompanyResponseDto> GetCompanyByIdAsync(Guid companyId)
    {
        var company = await _context.Companies.FindAsync(companyId);
        if (company == null)
            return null;

        return new CompanyResponseDto
        {
            Id = company.Id,
            CompanyName = company.CompanyName,
            TaxNumber = company.TaxNumber,
            TradeRegistryNumber = company.TradeRegistryNumber,
            Description = company.Description,
            Address = company.Address,
            City = company.City,
            District = company.District,
            PostalCode = company.PostalCode,
            PhoneNumber = company.PhoneNumber,
            Email = company.Email,
            WebsiteUrl = company.WebsiteUrl,
            CompanyManager = company.CompanyManager,
            IndustryType = company.IndustryType,
            LegalRepresentative = company.LegalRepresentative,
            EstablishedDate = company.EstablishedDate,
            CreatedDate = company.CreatedDate,
            UpdatedDate = company.UpdatedDate,
            Status = company.Status,
            IsTaxpayer = company.IsTaxpayer,
            IsRegisteredForVAT = company.IsRegisteredForVAT
        };
    }

    public async Task<List<CompanyResponseDto>> GetAllCompaniesAsync()
    {
        var companies = await _context.Companies.ToListAsync();
        return companies.Select(company => new CompanyResponseDto
        {
            Id = company.Id,
            CompanyName = company.CompanyName,
            TaxNumber = company.TaxNumber,
            TradeRegistryNumber = company.TradeRegistryNumber,
            Description = company.Description,
            Address = company.Address,
            City = company.City,
            District = company.District,
            PostalCode = company.PostalCode,
            PhoneNumber = company.PhoneNumber,
            Email = company.Email,
            WebsiteUrl = company.WebsiteUrl,
            CompanyManager = company.CompanyManager,
            IndustryType = company.IndustryType,
            LegalRepresentative = company.LegalRepresentative,
            EstablishedDate = company.EstablishedDate,
            CreatedDate = company.CreatedDate,
            UpdatedDate = company.UpdatedDate,
            Status = company.Status,
            IsTaxpayer = company.IsTaxpayer,
            IsRegisteredForVAT = company.IsRegisteredForVAT
        }).ToList();
    }

    public async Task<CompanyResponseDto> UpdateCompanyAsync(Guid companyId, UpdateCompanyRequestDto model)
    {
        var company = await _context.Companies.FindAsync(companyId);
        if (company == null)
            return null;

        // EstablishedDate'in UTC olduğundan emin olun
        DateTime establishedDate = model.EstablishedDate.Kind == DateTimeKind.Utc
            ? model.EstablishedDate
            : DateTime.SpecifyKind(model.EstablishedDate, DateTimeKind.Utc);

        company.CompanyName = model.CompanyName;
        company.TaxNumber = model.TaxNumber;
        company.TradeRegistryNumber = model.TradeRegistryNumber;
        company.Description = model.Description;
        company.Address = model.Address;
        company.City = model.City;
        company.District = model.District;
        company.PostalCode = model.PostalCode;
        company.PhoneNumber = model.PhoneNumber;
        company.Email = model.Email;
        company.WebsiteUrl = model.WebsiteUrl;
        company.CompanyManager = model.CompanyManager;
        company.IndustryType = model.IndustryType;
        company.LegalRepresentative = model.LegalRepresentative;
        company.EstablishedDate = establishedDate; // Güncellenmiş UTC tarih atanıyor
        company.IsTaxpayer = model.IsTaxpayer;
        company.IsRegisteredForVAT = model.IsRegisteredForVAT;
        company.Status = model.Status;
        company.UpdatedDate = DateTime.UtcNow;

        _context.Companies.Update(company);
        await _context.SaveChangesAsync();

        return new CompanyResponseDto
        {
            Id = company.Id,
            CompanyName = company.CompanyName,
            TaxNumber = company.TaxNumber,
            TradeRegistryNumber = company.TradeRegistryNumber,
            Description = company.Description,
            Address = company.Address,
            City = company.City,
            District = company.District,
            PostalCode = company.PostalCode,
            PhoneNumber = company.PhoneNumber,
            Email = company.Email,
            WebsiteUrl = company.WebsiteUrl,
            CompanyManager = company.CompanyManager,
            IndustryType = company.IndustryType,
            LegalRepresentative = company.LegalRepresentative,
            EstablishedDate = company.EstablishedDate,
            CreatedDate = company.CreatedDate,
            UpdatedDate = company.UpdatedDate,
            Status = company.Status,
            IsTaxpayer = company.IsTaxpayer,
            IsRegisteredForVAT = company.IsRegisteredForVAT
        };
    }


    public async Task<bool> DeleteCompanyAsync(Guid companyId)
    {
        var company = await _context.Companies.FindAsync(companyId);
        if (company == null)
            return false;

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
        return true;
    }
}
