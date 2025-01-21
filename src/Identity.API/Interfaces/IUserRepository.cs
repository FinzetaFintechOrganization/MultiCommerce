using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task<ApplicationUser> GetUserByIdAsync(string userId);
    Task<ApplicationUser> GetUserByEmailAsync(string email);
    Task<IList<string>> GetUserRolesAsync(ApplicationUser user);
    Task<bool> AssignRoleToUserAsync(ApplicationUser user, string roleName);
    Task<bool> RemoveRoleFromUserAsync(ApplicationUser user, string roleName);
    Task<bool> SaveUserAsync(ApplicationUser user);
}