using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICompanyService
{
    Task<CompanyResponseDto> CreateCompanyAsync(CreateCompanyDto model);
    Task<CompanyResponseDto> GetCompanyByIdAsync(Guid companyId);
    Task<CompanyResponseDto> UpdateCompanyAsync(Guid companyId, UpdateCompanyRequestDto model);
    Task<bool> DeleteCompanyAsync(Guid companyId);
    Task<List<CompanyResponseDto>> GetAllCompaniesAsync();  // Tüm şirketleri getiren metot
}
