using System.Threading.Tasks;

public interface IAccountService
{
    Task<RegisterResponseDto> Register(RegisterDto model);
    Task<LoginResponseDto> Login(LoginDto model, string returnUrl = null);
    Task Logout(string logoutId);
    Task<UserDto> GetUserInfo();
    Task<string> ChangePassword(ChangePasswordDto model);
    Task<string> EnableTwoFactorAuthentication();
    Task<string> ForgotPassword(ForgotPasswordDto model);
    Task<string> ResetPassword(ResetPasswordDto model);
}
