using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto model)
    {
        var result = await _companyService.CreateCompanyAsync(model);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetCompany), new { id = result.Data.Id }, result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await _companyService.GetCompanyByIdAsync(id);
        if (company == null)
            return NotFound();
        return Ok(company);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] UpdateCompanyDto model)
    {
        var company = await _companyService.UpdateCompanyAsync(id, model);
        if (company == null)
            return NotFound();
        return Ok(company);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        var result = await _companyService.DeleteCompanyAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllCompanies()
    {
        var companies = await _companyService.GetAllCompaniesAsync();
        return Ok(companies);
    }
}
