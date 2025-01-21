using System;

public class UpdateCompanyDto
{
    public string CompanyName { get; set; }
    public string TaxNumber { get; set; }
    public string TradeRegistryNumber { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string PostalCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string WebsiteUrl { get; set; }
    public string CompanyManager { get; set; }
    public string IndustryType { get; set; }
    public string LegalRepresentative { get; set; }
    public DateTime EstablishedDate { get; set; }
    public bool IsTaxpayer { get; set; }
    public bool IsRegisteredForVAT { get; set; }
    public CompanyStatus Status { get; set; }  // Durum güncellenebilir
}
