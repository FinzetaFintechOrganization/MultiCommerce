using System;
using IdentityServer.Models;

public class Consent
{
    // Benzersiz kimlik, her onay kaydının eşsiz olmasını sağlar. Her bir onay için GUID değeri oluşturulur.
    public Guid Id { get; set; } = Guid.NewGuid();

    // Onay veren kullanıcının kimliği. Bu, onayla ilişkili olan kullanıcının benzersiz ID'sini belirtir.
    public Guid UserID { get; set; }

    // Onayın türü. Kullanıcının verdiği onayın ne tür bir onay olduğunu belirtir (örneğin, gizlilik politikası, veri paylaşımı vb.).
    public string ConsentType { get; set; }

    // Onayın durumu. Bu alan, onayın geçerli olup olmadığını belirtir. Örneğin, "Verildi", "İptal Edildi", "Bekliyor" gibi durumlar olabilir.
    public ConsentStatus Status { get; set; }

    // Onayın verildiği tarih. Bu tarih, kullanıcının onayı verdiği zamanı belirtir.
    public DateTime DateGiven { get; set; } = DateTime.UtcNow;

    // Kullanıcı nesnesi. Onayı veren kullanıcının bilgilerini temsil eder.
    public virtual ApplicationUser User { get; set; }
}
