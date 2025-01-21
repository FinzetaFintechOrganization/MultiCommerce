using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICompanyService
{
    Task<Result<CompanyResponseDto>> CreateCompanyAsync(CreateCompanyDto model);
    Task<CompanyResponseDto> GetCompanyByIdAsync(Guid companyId);
    Task<Result<CompanyResponseDto>> UpdateCompanyAsync(Guid companyId, UpdateCompanyDto model);
    Task<bool> DeleteCompanyAsync(Guid companyId);
    Task<List<CompanyResponseDto>> GetAllCompaniesAsync();
}
