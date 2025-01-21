using System;
using System.Collections.Generic;

public class PermissionGroup
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } // Örnek: "Admin Permissions"
    public List<string> Permissions { get; set; } = new List<string>(); // Grup içindeki izinler
}