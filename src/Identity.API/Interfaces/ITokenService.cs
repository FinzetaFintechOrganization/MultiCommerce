using System.Threading.Tasks;

public interface ITokenService
{
    Task<string> CreateTokenAsync(ApplicationUser user);
}
