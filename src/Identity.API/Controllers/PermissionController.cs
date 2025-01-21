using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class PermissionController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPermissionService _permissionService; // İzinler için servis

        public PermissionController(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IPermissionService permissionService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _permissionService = permissionService;
        }

        // Tüm izinleri listele
        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permissions = await _permissionService.GetAllPermissionsAsync();
            return Ok(permissions);
        }

        // Kullanıcıya izin ata
        [HttpPost("assign-user-permission")]
        public async Task<IActionResult> AssignUserPermission([FromBody] UserPermissionDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound(new { Error = "User not found." });

            var result = await _permissionService.AssignPermissionToUserAsync(user, model.PermissionName);
            if (result)
                return Ok(new { Message = "Permission assigned successfully." });

            return BadRequest(new { Error = "Failed to assign permission." });
        }

        // Kullanıcıdan izin kaldır
        [HttpPost("remove-user-permission")]
        public async Task<IActionResult> RemoveUserPermission([FromBody] UserPermissionDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound(new { Error = "User not found." });

            var result = await _permissionService.RemovePermissionFromUserAsync(user, model.PermissionName);
            if (result)
                return Ok(new { Message = "Permission removed successfully." });

            return BadRequest(new { Error = "Failed to remove permission." });
        }

        // Kullanıcının izinlerini getir
        [HttpGet("user-permissions/{userId}")]
        public async Task<IActionResult> GetUserPermissions(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound(new { Error = "User not found." });

            var permissions = await _permissionService.GetUserPermissionsAsync(user);
            return Ok(permissions);
        }

        // Role izin ata
        [HttpPost("assign-role-permission")]
        public async Task<IActionResult> AssignRolePermission([FromBody] RolePermissionDto model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role == null)
                return NotFound(new { Error = "Role not found." });

            var result = await _permissionService.AssignPermissionToRoleAsync(role, model.PermissionName);
            if (result)
                return Ok(new { Message = "Permission assigned to role successfully." });

            return BadRequest(new { Error = "Failed to assign permission to role." });
        }

        // Rolün izinlerini getir
        [HttpGet("role-permissions/{roleId}")]
        public async Task<IActionResult> GetRolePermissions(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return NotFound(new { Error = "Role not found." });

            var permissions = await _permissionService.GetRolePermissionsAsync(role);
            return Ok(permissions);
        }
    }
}
