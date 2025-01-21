public class ChangePasswordResponseDto
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public string[] Errors { get; set; }
}
