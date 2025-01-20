using System.Collections.Generic;

public class RegisterResponseDto
{
    public bool Succeeded { get; set; }
    public IEnumerable<string>? Errors { get; set; }
    public string? UserId { get; set; }
}