using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityServer4.Services;
using IdentityServer4.Events;
using IdentityServer4.Stores;
using IdentityServer4.Extensions;

namespace Identity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IEventService _events;
        private readonly IClientStore _clientStore;
        private readonly ITokenService _tokenService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IIdentityServerInteractionService interaction,
            IEventService events,
            IClientStore clientStore,
            ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _events = events;
            _clientStore = clientStore;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponseDto>> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName));

                return Ok(new RegisterResponseDto
                {
                    Succeeded = true,
                    UserId = user.Id
                });
            }

            return BadRequest(new RegisterResponseDto
            {
                Succeeded = false,
                Errors = result.Errors.Select(e => e.Description).ToArray()
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginDto model, string returnUrl = null)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Perform password sign-in
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    return Unauthorized(new LoginResponseDto
                    {
                        Succeeded = false,
                        Errors = new[] { "User not found." }
                    });
                }

                // Trigger the login success event
                await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName, clientId: context?.Client?.ClientId));

                // Ensure context is not null before proceeding
                if (context != null)
                {
                    // If context is available, include returnUrl and token
                    var accessToken = await _tokenService.CreateTokenAsync(user);
                    return Ok(new LoginResponseDto
                    {
                        Succeeded = true,
                        ReturnUrl = returnUrl,
                        AccessToken = accessToken
                    });
                }

                // Handle case where context is null
                var tokenWithoutContext = await _tokenService.CreateTokenAsync(user);
                return Ok(new LoginResponseDto
                {
                    Succeeded = true,
                    AccessToken = tokenWithoutContext
                });
            }

            // Handle locked-out account
            if (result.IsLockedOut)
            {
                return BadRequest(new LoginResponseDto
                {
                    Succeeded = false,
                    Errors = new[] { "Account is locked out. Please try again later." }
                });
            }

            // Trigger login failure event
            await _events.RaiseAsync(new UserLoginFailureEvent(model.Email, "invalid credentials", clientId: context?.Client?.ClientId));

            return Unauthorized(new LoginResponseDto
            {
                Succeeded = false,
                Errors = new[] { "Invalid login attempt." }
            });
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(string logoutId)
        {
            var context = await _interaction.GetLogoutContextAsync(logoutId);

            if (User?.Identity.IsAuthenticated == true)
            {
                await _signInManager.SignOutAsync();
                await _events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));
            }

            return Ok(new
            {
                PostLogoutRedirectUri = context?.PostLogoutRedirectUri,
                ClientName = context?.ClientName,
                SignOutIframeUrl = context?.SignOutIFrameUrl
            });
        }


        [Authorize]
        [HttpGet("userinfo")]
        public async Task<ActionResult<UserDto>> GetUserInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var claims = await _userManager.GetClaimsAsync(user);

            return Ok(new UserDto
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Claims = claims.ToDictionary(c => c.Type, c => c.Value)
            });
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                await _events.RaiseAsync(new UserLoginSuccessEvent(
                    user.UserName,
                    user.Id,
                    user.UserName,
                    clientId: null
                ));

                await _signInManager.RefreshSignInAsync(user);
                return Ok(new { Message = "Password changed successfully" });
            }

            return BadRequest(new { Errors = result.Errors.Select(e => e.Description) });
        }

        [Authorize]
        [HttpPost("enable-two-factor")]
        public async Task<IActionResult> EnableTwoFactorAuthentication()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.SetTwoFactorEnabledAsync(user, true);

            if (result.Succeeded)
            {
                return Ok(new { Message = "Two-factor authentication enabled successfully." });
            }

            return BadRequest(new { Errors = result.Errors.Select(e => e.Description) });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new { Errors = new[] { "User not found" } });
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return Ok(new { Message = "Password reset link has been sent." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new { Errors = new[] { "User not found" } });
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Password reset successfully." });
            }

            return BadRequest(new { Errors = result.Errors.Select(e => e.Description) });
        }
    }
}
