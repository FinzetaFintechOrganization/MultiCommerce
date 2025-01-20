using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Identity.API
{
    public static class Config
    {
        // Api Resources - API'lere erişim için gerekli kaynaklar
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[] 
        {
            new ApiResource("Catalog")
            {
                Scopes = { "CatalogFullPermission" }
            }
        };

        // Identity Resources - Kullanıcı kimlik doğrulaması için gerekli kaynaklar
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[] 
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        // API Scope'ları - API erişim izinleri
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] 
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog service")
        };

        // Client konfigürasyonları - İstemciler için izin verilen grant türleri ve kapsamlar
        public static IEnumerable<Client> Clients(IConfiguration configuration) => new Client[] 
        {
            new Client
            {
                ClientId = "VisitorId",
                ClientName = "Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret(configuration["Authentication:Clients:VisitorId"].Sha256()) },
                AllowedScopes = { "CatalogFullPermission" }
            },
            new Client
            {
                ClientId = "ManagerId",
                ClientName = "Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret(configuration["Authentication:Clients:ManagerId"].Sha256()) },
                AllowedScopes = { "CatalogFullPermission" }
            },
            new Client
            {
                ClientId = "AdminId",
                ClientName = "Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret(configuration["Authentication:Clients:AdminId"].Sha256()) },
                AllowedScopes = { "CatalogFullPermission" }
            }
        };
    }
}
