using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Identity.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // Tüm rolleri listele
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles.Select(r => new
            {
                r.Id,
                r.Name
            });
            return Ok(roles);
        }

        // Yeni rol oluştur
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _roleManager.RoleExistsAsync(model.Name))
                return BadRequest(new { Error = "Role already exists." });

            var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));

            if (result.Succeeded)
                return Ok(new { Message = "Role created successfully." });

            return BadRequest(new { Errors = result.Errors });
        }

        // Rol güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] RoleDto model)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound(new { Error = "Role not found." });

            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
                return Ok(new { Message = "Role updated successfully." });

            return BadRequest(new { Errors = result.Errors });
        }

        // Rol sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound(new { Error = "Role not found." });

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
                return Ok(new { Message = "Role deleted successfully." });

            return BadRequest(new { Errors = result.Errors });
        }

        // Kullanıcıya rol ata
        [HttpPost("assign-user-role")]
        public async Task<IActionResult> AssignUserRole([FromBody] UserRoleDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound(new { Error = "User not found." });

            if (!await _roleManager.RoleExistsAsync(model.RoleName))
                return NotFound(new { Error = "Role not found." });

            var result = await _userManager.AddToRoleAsync(user, model.RoleName);

            if (result.Succeeded)
                return Ok(new { Message = "Role assigned successfully." });

            return BadRequest(new { Errors = result.Errors });
        }

        // Kullanıcıdan rol kaldır
        [HttpPost("remove-user-role")]
        public async Task<IActionResult> RemoveUserRole([FromBody] UserRoleDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound(new { Error = "User not found." });

            var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);

            if (result.Succeeded)
                return Ok(new { Message = "Role removed successfully." });

            return BadRequest(new { Errors = result.Errors });
        }

        // Kullanıcının rollerini getir
        [HttpGet("user-roles/{userId}")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound(new { Error = "User not found." });

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }
    }

}