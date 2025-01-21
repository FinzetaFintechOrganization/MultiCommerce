using System;
using IdentityServer.Models;

public class PasswordReset
{
    // Benzersiz kimlik, her bir şifre sıfırlama isteği için benzersiz bir GUID oluşturulur.
    public Guid Id { get; set; } = Guid.NewGuid();

    // Şifre sıfırlama işlemi yapılan kullanıcının kimliği.
    // Bu alan, şifre sıfırlama talebinin hangi kullanıcıya ait olduğunu belirtir.
    public Guid UserID { get; set; }

    // Şifre sıfırlama işlemi için oluşturulan benzersiz token.
    // Token, şifre sıfırlama işlemi sırasında kullanıcıya gönderilir ve kullanıcının bu token'ı doğrulayarak şifreyi sıfırlaması sağlanır.
    public string Token { get; set; }

    // Şifre sıfırlama talebinin yapıldığı tarih ve saat.
    // Bu tarih, şifre sıfırlama işlemi için başlangıç zamanını belirtir.
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;

    // Şifre sıfırlama işlemi için token'ın geçerliliğinin sona ereceği tarih.
    // Bu tarih, şifre sıfırlama işleminin token'ının ne zaman geçerli olduğunu belirler. Genellikle sınırlı bir süre verilir.
    public DateTime ExpirationDate { get; set; }

    // Şifre sıfırlama işlemi başarıyla tamamlandığında bu tarih set edilir.
    // Eğer token kullanılmamışsa, bu alan null (boş) olacaktır. Token kullanıldığında, bu alan sıfırlama zamanını içerir.
    public DateTime? UsedDate { get; set; }

    // Şifre sıfırlama işlemi yapılan kullanıcıyı temsil eder.
    // Bu, kullanıcıyı tanımlayan ApplicationUser nesnesi ile ilişkilendirilmiştir.
    public virtual ApplicationUser User { get; set; }
}
