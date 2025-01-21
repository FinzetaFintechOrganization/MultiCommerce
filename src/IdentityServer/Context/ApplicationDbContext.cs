using IdentityServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace IdentityServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Consent> Consents { get; set; }
        public DbSet<LoginAttempt> LoginAttempts { get; set; }
        public DbSet<OAuthProvider> OAuthProviders { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<TwoFactorAuth> TwoFactorAuths { get; set; }
        public DbSet<UserOAuth> UserOAuths { get; set; }
        public DbSet<UserSecurityQuestion> UserSecurityQuestions { get; set; }
    }
}
