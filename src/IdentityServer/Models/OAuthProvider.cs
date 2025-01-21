using System;

public class OAuthProvider
{
    // Benzersiz kimlik, her OAuth sağlayıcısının eşsiz olmasını sağlar. GUID değeriyle her bir sağlayıcı için benzersiz bir kimlik atanır.
    public Guid Id { get; set; } = Guid.NewGuid();

    // OAuth sağlayıcısının adı. Bu, OAuth sağlayıcısını tanımlayan isimdir (örneğin, "Google", "Facebook").
    public string ProviderName { get; set; }

    // OAuth sağlayıcısının uygulama için belirlediği Client ID. OAuth2.0 kimlik doğrulaması sırasında kullanılan bir parametredir.
    public string ClientID { get; set; }

    // OAuth sağlayıcısının uygulama için belirlediği Client Secret. Bu, Client ID ile birlikte kullanılır ve güvenli bir şekilde saklanmalıdır.
    public string ClientSecret { get; set; }

    // OAuth sağlayıcısının uygulamanın redirekte edileceği URL. Kullanıcı kimlik doğrulamasını tamamladıktan sonra kullanıcı bu URL'ye yönlendirilir.
    public string RedirectUrl { get; set; }

    // OAuth erişim izinleri. Bu, OAuth sağlayıcısına verilen izinleri belirtir (örneğin, "email", "profile").
    public string Scopes { get; set; }
}
