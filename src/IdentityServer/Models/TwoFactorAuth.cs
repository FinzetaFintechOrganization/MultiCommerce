using System;
using IdentityServer.Models;

public class TwoFactorAuth
{
    // Benzersiz kimlik. Her iki faktörlü doğrulama kaydına benzersiz bir GUID atanır.
    public Guid Id { get; set; } = Guid.NewGuid();

    // Bu iki faktörlü doğrulama kaydının hangi kullanıcıya ait olduğunu belirten kullanıcı kimliği.
    public Guid UserID { get; set; }

    // İki faktörlü doğrulamanın etkin olup olmadığını belirten bayrak (true: etkin, false: devre dışı).
    public bool IsEnabled { get; set; }

    // Kullanıcıya ait gizli anahtar. Bu anahtar, kullanıcı doğrulama işlemleri için kullanılır.
    public string SecretKey { get; set; }

    // Kullanıcı için oluşturulan kurtarma kodları. Bu, kullanıcının iki faktörlü doğrulama cihazına erişim kaybı durumunda kullanılabilir.
    public string RecoveryCodes { get; set; }

    // Kaydın son güncellenme tarihi. İki faktörlü doğrulama ayarlarında yapılan değişikliklerin kaydını tutar.
    public DateTime LastUpdatedDate { get; set; } = DateTime.UtcNow;

    // Bu iki faktörlü doğrulamanın hangi kullanıcıya ait olduğunu belirtir (Navigation property).
    public virtual ApplicationUser User { get; set; }
}
