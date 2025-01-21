using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer.Migrations
{
    /// <inheritdoc />
    public partial class updateıds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserSecurityQuestionID",
                table: "UserSecurityQuestions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserOAuthID",
                table: "UserOAuths",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TwoFactorAuthID",
                table: "TwoFactorAuths",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SessionID",
                table: "Sessions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SecurityQuestionID",
                table: "SecurityQuestions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RolePermissionID",
                table: "RolePermissions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PermissionID",
                table: "Permissions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PasswordResetID",
                table: "PasswordResets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OAuthProviderID",
                table: "OAuthProviders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LoginAttemptID",
                table: "LoginAttempts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ConsentID",
                table: "Consents",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AuditLogID",
                table: "AuditLogs",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserSecurityQuestions",
                newName: "UserSecurityQuestionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserOAuths",
                newName: "UserOAuthID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TwoFactorAuths",
                newName: "TwoFactorAuthID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sessions",
                newName: "SessionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SecurityQuestions",
                newName: "SecurityQuestionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RolePermissions",
                newName: "RolePermissionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Permissions",
                newName: "PermissionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PasswordResets",
                newName: "PasswordResetID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OAuthProviders",
                newName: "OAuthProviderID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoginAttempts",
                newName: "LoginAttemptID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Consents",
                newName: "ConsentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AuditLogs",
                newName: "AuditLogID");
        }
    }
}
