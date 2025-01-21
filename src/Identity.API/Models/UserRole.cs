using System;

public class UserRole
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    public string RoleId { get; set; }
    public ApplicationRole Role { get; set; }
}