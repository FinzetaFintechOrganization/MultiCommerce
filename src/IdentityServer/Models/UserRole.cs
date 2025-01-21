using System;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

public class UserRole : IdentityUserRole<Guid>
{
    // Kullanıcının bir role atanma tarihi. Bu, kullanıcıya role atandığı zamanı kaydeder.
    public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

    // Kullanıcı bilgilerini tutan navigation property. Hangi kullanıcı bu role atanmışsa, onun bilgilerine erişilir.
    public virtual ApplicationUser User { get; set; }

    // Role bilgilerini tutan navigation property. Bu kullanıcı hangi role atanmışsa, o role'a ait bilgilere erişilir.
    public virtual ApplicationRole Role { get; set; }
}
