using System;
using System.Threading.Tasks;
using Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthController(
        UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<ActionResult<RegisterResponseDto>> Register(RegisterDto model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RegisterResponseDto
                {
                    Succeeded = false,
                });
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true // Eğer email doğrulama istiyorsanız false yapın
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                
                return Ok(new RegisterResponseDto
                {
                    Succeeded = true,
                    UserId = user.Id
                });
            }

            return BadRequest(new RegisterResponseDto
            {
                Succeeded = false,
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RegisterResponseDto
            {
                Succeeded = false,
                Errors = new[] { "An error occurred while processing your request." }
            });
        }
    }
}