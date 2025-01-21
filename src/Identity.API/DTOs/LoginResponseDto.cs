public class LoginResponseDto
{
    public bool Succeeded { get; set; }
    public string AccessToken { get; set; }
    public string[] Errors { get; set; }
    public string ReturnUrl { get; set; }
}