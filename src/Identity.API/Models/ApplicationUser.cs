using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Kullanıcının izinlerini tutacak özellik
    public List<string> Permissions { get; set; } = new List<string>();
}