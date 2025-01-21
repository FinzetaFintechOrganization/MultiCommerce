using System;
using IdentityServer.Models;

public class Session
{
    // Benzersiz kimlik. Her oturum için benzersiz bir GUID atanır.
    public Guid Id { get; set; } = Guid.NewGuid();

    // Bu oturumu başlatan kullanıcının kimliği. Bu, oturumun hangi kullanıcıya ait olduğunu belirtir.
    public Guid UserID { get; set; }

    // Kullanıcının oturum açarken aldığı token. Bu token, oturumun geçerliliğini ve doğruluğunu sağlar.
    public string Token { get; set; }

    // Oturumun veritabanına kaydedildiği tarih. Oturum başlatıldığında bu tarih UTC formatında kaydedilir.
    public DateTime IssuedDate { get; set; } = DateTime.UtcNow;

    // Oturumun sonlanacağı tarih. Token'in geçerliliği bitene kadar oturum aktif olur.
    public DateTime ExpiresDate { get; set; }

    // Oturum açan kullanıcının IP adresi. Bu alan, kullanıcı oturum açarken sistemdeki IP adresini saklar.
    public string IPAddress { get; set; }

    // Oturum açan kullanıcının cihaz bilgisi. Bu, kullanıcıyı tanımak ve oturumu izlemek için kullanılır.
    public string DeviceInfo { get; set; }

    // Oturumun mevcut durumu. Örneğin, aktif, sonlandırılmış, beklemede gibi.
    public SessionStatus Status { get; set; }

    // Bu oturumun hangi kullanıcıya ait olduğunu belirtir. (Navigation property)
    public virtual ApplicationUser User { get; set; }
}
