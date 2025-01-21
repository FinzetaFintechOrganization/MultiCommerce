// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        // Define identity resources for OpenId, Profile, and additional identity-related claims
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),  // Email identity resource
                new IdentityResources.Phone()   // Phone identity resource
            };

        // Define API scopes for access control (permissions available for clients)
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1", "Scope 1 Description"),
                new ApiScope("scope2", "Scope 2 Description"),
                new ApiScope("scope3", "Scope 3 Description"),
                new ApiScope("admin", "Admin scope for privileged access")
            };

        // Define API resources (separate from identity resources)
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("api1", "API 1 Resource")
                {
                    Scopes = { "scope1", "scope2" },  // These are the scopes that clients can request
                    UserClaims = { "role", "admin" }  // Optional: Claims that should be included in the API resource
                },
                new ApiResource("api2", "API 2 Resource")
                {
                    Scopes = { "scope3", "admin" },
                    UserClaims = { "role" }
                }
            };

        // Define clients with various grant types and configurations
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // Client Credentials Flow (machine-to-machine)
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                    AllowedScopes = { "scope1", "scope2" }
                },

                // Code Flow with PKCE (Interactive User Login)
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "email", "scope1", "scope2" }
                }
            };
    }
}
