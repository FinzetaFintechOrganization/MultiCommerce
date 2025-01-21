using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using IdentityServer.Data;

public class CompanyService : ICompanyService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CompanyService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<CompanyResponseDto>> CreateCompanyAsync(CreateCompanyDto model)
    {
        bool isCompanyNameExists = await _context.Companies
            .AnyAsync(c => c.CompanyName == model.CompanyName);

        if (isCompanyNameExists)
        {
            return Result<CompanyResponseDto>.Failure(new ErrorResponseDto
            {
                StatusCode = 400,
                ErrorCode = "DUPLICATE_COMPANYNAME",
                Message = "The company name already exists. Please use a different name.",
                Timestamp = DateTime.UtcNow,
                TraceId = Guid.NewGuid().ToString(),
            });
        }

        bool isTaxNumberExists = await _context.Companies
            .AnyAsync(c => c.TaxNumber == model.TaxNumber);

        if (isTaxNumberExists)
        {
            return Result<CompanyResponseDto>.Failure(new ErrorResponseDto
            {
                StatusCode = 400,
                ErrorCode = "DUPLICATE_TAXNUMBER",
                Message = "A tax ID number already exists. Please use a different tax ID number.",
                Timestamp = DateTime.UtcNow,
                TraceId = Guid.NewGuid().ToString(),
            });
        }

        DateTime establishedDate = model.EstablishedDate.Kind == DateTimeKind.Utc
            ? model.EstablishedDate
            : DateTime.SpecifyKind(model.EstablishedDate, DateTimeKind.Utc);

        var company = _mapper.Map<Company>(model);
        company.EstablishedDate = establishedDate;
        company.CreatedDate = DateTime.UtcNow;
        company.UpdatedDate = DateTime.UtcNow;
        company.Status = CompanyStatus.Active;

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        var companyResponse = _mapper.Map<CompanyResponseDto>(company);

        return Result<CompanyResponseDto>.Success(companyResponse);
    }


    public async Task<CompanyResponseDto> GetCompanyByIdAsync(Guid companyId)
    {
        var company = await _context.Companies.FindAsync(companyId);
        if (company == null)
            return null;

        return _mapper.Map<CompanyResponseDto>(company);
    }

    public async Task<List<CompanyResponseDto>> GetAllCompaniesAsync()
    {
        var companies = await _context.Companies.ToListAsync();
        return _mapper.Map<List<CompanyResponseDto>>(companies);
    }

    public async Task<Result<CompanyResponseDto>> UpdateCompanyAsync(Guid companyId, UpdateCompanyDto model)
    {
        var company = await _context.Companies.FindAsync(companyId);
        if (company == null)
        {
            return Result<CompanyResponseDto>.Failure(new ErrorResponseDto
            {
                StatusCode = 404,
                ErrorCode = "COMPANY_NOT_FOUND",
                Message = "Company not found.",
                Timestamp = DateTime.UtcNow,
                TraceId = Guid.NewGuid().ToString()
            });
        }

        bool isCompanyNameExists = await _context.Companies
            .AnyAsync(c => c.CompanyName == model.CompanyName && c.Id != companyId);

        if (isCompanyNameExists)
        {
            return Result<CompanyResponseDto>.Failure(new ErrorResponseDto
            {
                StatusCode = 400,
                ErrorCode = "DUPLICATE_COMPANYNAME",
                Message = "The company name already exists. Please use a different name.",
                Timestamp = DateTime.UtcNow,
                TraceId = Guid.NewGuid().ToString()
            });
        }

        bool isTaxNumberExists = await _context.Companies
            .AnyAsync(c => c.TaxNumber == model.TaxNumber && c.Id != companyId);

        if (isTaxNumberExists)
        {
            return Result<CompanyResponseDto>.Failure(new ErrorResponseDto
            {
                StatusCode = 400,
                ErrorCode = "DUPLICATE_TAXNUMBER",
                Message = "A tax ID number already exists. Please use a different tax ID number.",
                Timestamp = DateTime.UtcNow,
                TraceId = Guid.NewGuid().ToString()
            });
        }

        DateTime establishedDate = model.EstablishedDate.Kind == DateTimeKind.Utc
            ? model.EstablishedDate
            : DateTime.SpecifyKind(model.EstablishedDate, DateTimeKind.Utc);

        _mapper.Map(model, company);
        company.EstablishedDate = establishedDate;
        company.UpdatedDate = DateTime.UtcNow;

        _context.Companies.Update(company);
        await _context.SaveChangesAsync();

        var companyResponse = _mapper.Map<CompanyResponseDto>(company);

        return Result<CompanyResponseDto>.Success(companyResponse);
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
