using System;
using IdentityServer.Models;

public class LoginAttempt
{
    // Benzersiz kimlik, her giriş denemesi kaydının eşsiz olmasını sağlar. Her bir giriş denemesi için GUID değeri oluşturulur.
    public Guid Id { get; set; } = Guid.NewGuid();

    // Giriş yapan kullanıcının kimliği. Bu, giriş denemesiyle ilişkili olan kullanıcının benzersiz ID'sini belirtir.
    public Guid UserID { get; set; }

    // Giriş denemesinin tarihi ve saati. Bu tarih, kullanıcının giriş denemesi yaptığı zamanı belirtir.
    public DateTime AttemptDate { get; set; } = DateTime.UtcNow;

    // Giriş denemesinin başarılı olup olmadığını belirten bir bayrak. Başarılı girişler için 'true', başarısız girişler için 'false' değeri alır.
    public bool Success { get; set; }

    // Giriş denemesini yapan kullanıcının IP adresi. Bu, girişin hangi IP adresinden yapıldığını belirtir.
    public string IPAddress { get; set; }

    // Giriş denemesini yapan kullanıcının cihaz bilgileri. Cihazın işletim sistemi, tarayıcı vb. bilgilerini içerebilir.
    public string DeviceInfo { get; set; }

    // Kullanıcı nesnesi. Giriş denemesiyle ilişkili olan kullanıcıyı temsil eder.
    public virtual ApplicationUser User { get; set; }
}
