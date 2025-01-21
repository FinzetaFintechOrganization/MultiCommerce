using System.Collections.Generic;

public class UserDto
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Dictionary<string, string> Claims { get; set; }
}