using System;

public class Permission
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } // Örnek: "Read", "Write"
    public string Description { get; set; } // İzin açıklaması
}