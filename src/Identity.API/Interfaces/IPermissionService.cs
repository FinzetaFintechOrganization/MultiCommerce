using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

public interface IPermissionService
{
    Task<List<string>> GetAllPermissionsAsync();
    Task<bool> AssignPermissionToUserAsync(ApplicationUser user, string permissionName);
    Task<bool> RemovePermissionFromUserAsync(ApplicationUser user, string permissionName);
    Task<List<string>> GetUserPermissionsAsync(ApplicationUser user);
    Task<bool> AssignPermissionToRoleAsync(IdentityRole role, string permissionName);
    Task<List<string>> GetRolePermissionsAsync(IdentityRole role);
}