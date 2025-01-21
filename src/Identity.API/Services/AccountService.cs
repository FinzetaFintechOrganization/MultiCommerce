using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Services;
using IdentityServer4.Events;
using IdentityServer4.Extensions;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IIdentityServerInteractionService _interaction;
    private readonly IEventService _events;
    private readonly ITokenService _tokenService;

    public AccountService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IIdentityServerInteractionService interaction,
        IEventService events,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _interaction = interaction;
        _events = events;
        _tokenService = tokenService;
    }

    public async Task<RegisterResponseDto> Register(RegisterDto model)
    {
        if (!ModelState.IsValid)
        {
            return new RegisterResponseDto
            {
                Succeeded = false,
                Errors = new[] { "Invalid model state" }
            };
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

            return new RegisterResponseDto
            {
                Succeeded = true,
                UserId = user.Id
            };
        }

        return new RegisterResponseDto
        {
            Succeeded = false,
            Errors = result.Errors.Select(e => e.Description).ToArray()
        };
    }

    public async Task<LoginResponseDto> Login(LoginDto model, string returnUrl = null)
    {
        var context = await _interaction.GetAuthorizationContextAsync(returnUrl);

        if (!ModelState.IsValid)
        {
            return new LoginResponseDto
            {
                Succeeded = false,
                Errors = new[] { "Invalid model state" }
            };
        }

        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new LoginResponseDto
                {
                    Succeeded = false,
                    Errors = new[] { "User not found." }
                };
            }

            await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName, clientId: context?.Client?.ClientId));

            var accessToken = await _tokenService.CreateTokenAsync(user);
            return new LoginResponseDto
            {
                Succeeded = true,
                ReturnUrl = returnUrl,
                AccessToken = accessToken
            };
        }

        if (result.IsLockedOut)
        {
            return new LoginResponseDto
            {
                Succeeded = false,
                Errors = new[] { "Account is locked out. Please try again later." }
            };
        }

        await _events.RaiseAsync(new UserLoginFailureEvent(model.Email, "invalid credentials", clientId: context?.Client?.ClientId));

        return new LoginResponseDto
        {
            Succeeded = false,
            Errors = new[] { "Invalid login attempt." }
        };
    }

    public async Task Logout(string logoutId)
    {
        var context = await _interaction.GetLogoutContextAsync(logoutId);

        if (context != null && User?.Identity.IsAuthenticated == true)
        {
            await _signInManager.SignOutAsync();
            await _events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));
        }
    }

    public async Task<UserDto> GetUserInfo()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return null;
        }

        var claims = await _userManager.GetClaimsAsync(user);

        return new UserDto
        {
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Claims = claims.ToDictionary(c => c.Type, c => c.Value)
        };
    }

    public async Task<string> ChangePassword(ChangePasswordDto model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return "User not found";
        }

        var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        if (result.Succeeded)
        {
            await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName, clientId: null));
            await _signInManager.RefreshSignInAsync(user);
            return "Password changed successfully";
        }

        return string.Join(", ", result.Errors.Select(e => e.Description));
    }

    public async Task<string> EnableTwoFactorAuthentication()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return "User not found";
        }

        var result = await _userManager.SetTwoFactorEnabledAsync(user, true);

        if (result.Succeeded)
        {
            return "Two-factor authentication enabled successfully.";
        }

        return string.Join(", ", result.Errors.Select(e => e.Description));
    }

    public async Task<ForgotPasswordResponseDto> ForgotPassword(ForgotPasswordDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return new ForgotPasswordResponseDto { Errors = new[] { "User not found" } };
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        return new ForgotPasswordResponseDto { Message = "Password reset link has been sent." };
    }

    public async Task<string> ResetPassword(ResetPasswordDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return "User not found";
        }

        var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
        if (result.Succeeded)
        {
            return "Password reset successfully.";
        }

        return string.Join(", ", result.Errors.Select(e => e.Description));
    }
}
