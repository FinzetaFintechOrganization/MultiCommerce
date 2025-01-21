using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRoleRepository
{
    Task<IdentityRole> GetRoleByIdAsync(string roleId);
    Task<IdentityRole> GetRoleByNameAsync(string roleName);
    Task<IList<IdentityRole>> GetAllRolesAsync();
    Task<bool> CreateRoleAsync(string roleName);
    Task<bool> UpdateRoleAsync(IdentityRole role);
    Task<bool> DeleteRoleAsync(IdentityRole role);
    Task<bool> RoleExistsAsync(string roleName);
}
