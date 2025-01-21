using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public class ApplicationRole : IdentityRole
{
    public string Description { get; set; } // Rol açıklaması
    public List<string> Permissions { get; set; } = new List<string>(); // Role bağlı izinler
}