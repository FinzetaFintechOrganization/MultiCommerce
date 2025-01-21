using System;
using IdentityServer.Models;

public class AuditLog
{
    // Açıklama: Audit log'un benzersiz kimliği. Her log kaydının benzersiz bir GUID değeri vardır.
    public Guid Id { get; set; } = Guid.NewGuid();

    // Açıklama: Log kaydını oluşturan kullanıcının kimliği. Bu, log kaydının hangi kullanıcı tarafından oluşturulduğunu gösterir.
    public Guid UserID { get; set; }

    // Açıklama: Kullanıcının gerçekleştirdiği işlem türü. Örneğin, "Giriş", "Şifre Değişikliği", "Kullanıcı Silme" gibi işlemleri belirler.
    public string Action { get; set; }

    // Açıklama: İşlemin yapıldığı tarih ve saat. Bu, log kaydının ne zaman oluşturulduğunu belirler.
    public DateTime ActionDate { get; set; } = DateTime.UtcNow;

    // Açıklama: Kullanıcının işlem yaptığı IP adresi. Bu, güvenlik amacıyla kullanıcının işlem yaptığı cihazın IP adresini kaydeder.
    public string IPAddress { get; set; }

    // Açıklama: Kullanıcının işlem yaptığı cihazın bilgisi. Bu, kullanıcıların hangi cihazlardan sisteme eriştiklerini belirlemek için kullanılır.
    public string DeviceInfo { get; set; }

    // Açıklama: Gerçekleştirilen işlemle ilgili daha fazla detay. Bu alan, daha fazla açıklama veya işlemle ilgili ek bilgi içerir.
    public string Details { get; set; }

    // Açıklama: Audit log kaydının ilişkili olduğu kullanıcı. Bu ilişki, log kaydının hangi kullanıcı tarafından oluşturulduğunu belirtir.
    public virtual ApplicationUser User { get; set; }
}
