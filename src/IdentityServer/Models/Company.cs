using System;
using System.Collections.Generic;
using IdentityServer.Models;

public class Company
{
    // Şirketin benzersiz kimliği. Her bir şirketin eşsiz bir GUID değeri vardır.
    public Guid Id { get; set; } 

    // Şirketin adı. Şirketin ticari ismini belirtir.
    public string CompanyName { get; set; } 

    // Şirketin vergi numarası. Türkiye'deki şirketler için zorunludur ve şirketin vergi dairesine kayıtlı olduğunu gösterir.
    public string TaxNumber { get; set; } 

    // Şirketin ticaret sicil numarası. Türkiye'deki şirketler için zorunludur ve şirketin ticaret odasına kayıtlı olduğunu belirtir.
    public string TradeRegistryNumber { get; set; } 

    // Şirketin kısa açıklaması. Şirket hakkında kısa bilgi sağlar.
    public string Description { get; set; } 

    // Şirketin adresi. Şirketin fiziksel adresini belirtir.
    public string Address { get; set; } 

    // Şirketin bulunduğu şehir. Türkiye'deki şehir ismi.
    public string City { get; set; } 

    // Şirketin bulunduğu ilçe. Türkiye'deki ilçe ismi.
    public string District { get; set; } 

    // Şirketin posta kodu. Şirketin adresine ait posta kodu.
    public string PostalCode { get; set; } 

    // Şirketin telefon numarası. Şirketin iletişim telefonunu belirtir.
    public string PhoneNumber { get; set; } 

    // Şirketin e-posta adresi. Şirketin iletişim için kullanılan e-posta adresi.
    public string Email { get; set; } 

    // Şirketin internet sitesi. Şirketin web adresini belirtir. (isteğe bağlı)
    public string WebsiteUrl { get; set; } 

    // Şirketin yöneticisinin bilgisi. Şirket yöneticisinin adı ve soyadı. (isteğe bağlı)
    public string CompanyManager { get; set; } 

    // Şirketin faaliyet türü. Şirketin faaliyet gösterdiği sektör veya alanı belirtir. (örneğin yazılım, perakende, üretim)
    public string IndustryType { get; set; }

    // Yasal temsilci. Şirketin yasal temsilcisinin adı. (Örneğin, şirketin genel müdürü)
    public string LegalRepresentative { get; set; } 

    // Şirketin kurulduğu tarih. Şirketin kuruluş tarihi.
    public DateTime EstablishedDate { get; set; } 

    // Şirketin oluşturulma tarihi. Bu tarih, şirketin sisteme kaydedildiği zamanı belirtir. Varsayılan olarak UTC zamanı atanır.
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow; 

    // Şirketin güncellenme tarihi. Şirket kaydında yapılan son değişiklik tarihi.
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow; 

    // Şirketle ilişkili kullanıcılar. Şirkete ait olan tüm kullanıcıları temsil eder.
    public virtual ICollection<ApplicationUser> Users { get; set; }

    // Şirketle ilişkili roller. Şirketteki tüm rollerin listesini tutar.
    public virtual ICollection<ApplicationRole> Roles { get; set; }

    // Şirketin faaliyet durumu. Şirketin aktif olup olmadığını gösterir. (Aktif, Pasif, Duraklatılmış vb.)
    public CompanyStatus Status { get; set; } 

    // Şirketin vergi durumu. Şirketin vergi mükellefi olup olmadığını belirtir (evet/hayır).
    public bool IsTaxpayer { get; set; } 

    // Şirketin KDV'ye kayıtlı olup olmadığını belirtir. (Evet/Hayır)
    public bool IsRegisteredForVAT { get; set; } 
}
