using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models
{
    public class ApplicationUser : IdentityUser<Guid> 
    {
        // Açıklama: Kullanıcının adı. Bu, kullanıcının kişisel bilgisini tutan bir alandır.
        public string FirstName { get; set; }

        // Açıklama: Kullanıcının soyadı. Kullanıcının kişisel bilgilerini tamamlar.
        public string LastName { get; set; }

        // Açıklama: Kullanıcının doğum tarihi. Bu, yaş doğrulaması veya yaşa bağlı başka işlemler için kullanılabilir.
        public DateTime DateOfBirth { get; set; }

        // Açıklama: Kullanıcının profil resmi için URL. Bu, kullanıcıların görsel kimliğini oluşturur.
        public string ProfilePictureUrl { get; set; }

        // Açıklama: Kullanıcının mevcut durumu. Örneğin, aktif, pasif, askıya alınmış gibi durumlar olabilir.
        public UserStatus Status { get; set; }

        // Açıklama: Kullanıcının hesap oluşturulma tarihi. Varsayılan olarak UTC zamanında atanır.
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Açıklama: Kullanıcı bilgilerinde yapılan son güncellemenin tarihi. Varsayılan olarak UTC zamanında atanır.
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        // Açıklama: Kullanıcının ait olduğu şirketin ID'si. Bir kullanıcı sadece bir şirkete ait olabilir.
        public Guid CompanyID { get; set; }

        // Açıklama: Kullanıcının ait olduğu şirketin nesnesi. Bu ilişki, kullanıcının şirketiyle olan bağlantısını gösterir.
        public virtual Company Company { get; set; }

        // Açıklama: Kullanıcının rol koleksiyonu. Kullanıcı birden fazla role sahip olabilir.
        public virtual ICollection<UserRole> UserRoles { get; set; }

        // Açıklama: Kullanıcının giriş denemeleri. Bu, kullanıcı güvenliği için önemli bir koleksiyondur ve başarısız giriş denemeleri içerir.
        public virtual ICollection<LoginAttempt> LoginAttempts { get; set; }

        // Açıklama: Kullanıcının yaptığı eylemleri veya sistemdeki değişiklikleri izlemek için kullanılan denetim kayıtları.
        public virtual ICollection<AuditLog> AuditLogs { get; set; }

        // Açıklama: Kullanıcının iki faktörlü kimlik doğrulama bilgileri. Bu, güvenlik amacıyla ek bir doğrulama yöntemi sağlar.
        public virtual ICollection<TwoFactorAuth> TwoFactorAuths { get; set; }

        // Açıklama: Kullanıcının aktif olduğu oturumların koleksiyonu. Kullanıcıların sisteme giriş yaptığı oturumlar burada tutulur.
        public virtual ICollection<Session> Sessions { get; set; }

        // Açıklama: Kullanıcının parolasını sıfırlama işlemleri. Kullanıcı şifresini sıfırlamak istediğinde bu bilgiler kaydedilir.
        public virtual ICollection<PasswordReset> PasswordResets { get; set; }

        // Açıklama: Kullanıcının yanıtladığı güvenlik soruları. Hesap kurtarma ve güvenlik işlemleri için önemlidir.
        public virtual ICollection<UserSecurityQuestion> UserSecurityQuestions { get; set; }

        // Açıklama: Kullanıcının OAuth bağlantılarını temsil eder. Kullanıcı, farklı üçüncü taraf servislerle bağlanabilir.
        public virtual ICollection<UserOAuth> UserOAuths { get; set; }

        // Açıklama: Kullanıcının onayladığı izinler. Bu, kullanıcıların bir servisle etkileşime girerken verdiği izinleri tutar.
        public virtual ICollection<Consent> Consents { get; set; }
    }
}
