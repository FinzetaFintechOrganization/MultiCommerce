using System;
using IdentityServer.Models;

public class UserOAuth
{
    // Benzersiz kimlik. Bu kayıt her kullanıcı için benzersiz bir GUID ile tanımlanır.
    public Guid Id { get; set; } = Guid.NewGuid();

    // Bu OAuth kaydının hangi kullanıcıya ait olduğunu belirten kullanıcı kimliği.
    public Guid UserID { get; set; }

    // OAuth sağlayıcısının kimliği. Hangi OAuth sağlayıcısının kullanıldığını belirtir (örneğin, Google, Facebook vb.).
    public Guid OAuthProviderID { get; set; }

    // OAuth sağlayıcısının, kullanıcının hesabını tanımlamak için kullandığı benzersiz kullanıcı kimliği.
    public string ProviderUserID { get; set; }

    // OAuth erişim token'ı. Kullanıcının OAuth sağlayıcısından aldığı erişim anahtarını içerir.
    public string AccessToken { get; set; }

    // OAuth yenileme token'ı. Erişim token'ı süresi dolarsa, kullanıcıya yeni bir erişim token'ı almak için kullanılır.
    public string RefreshToken { get; set; }

    // Token'ın geçerlilik süresi. Erişim token'ı veya yenileme token'ının ne zaman sona ereceğini belirler.
    public DateTime TokenExpiryDate { get; set; }

    // Bu kaydın hangi kullanıcıya ait olduğunu belirtir (Navigation property).
    public virtual ApplicationUser User { get; set; }

    // Bu kaydın hangi OAuth sağlayıcısı ile ilişkili olduğunu belirtir (Navigation property).
    public virtual OAuthProvider OAuthProvider { get; set; }
}
