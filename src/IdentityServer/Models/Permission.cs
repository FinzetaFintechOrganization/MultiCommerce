using System;
using System.Collections.Generic;

public class Permission
{
    // Benzersiz kimlik. Her bir izin için benzersiz bir GUID oluşturulur.
    // Bu alan, her iznin tanımlanması için kullanılır.
    public Guid Id { get; set; } = Guid.NewGuid();

    // İzin adı. Bu, iznin ne olduğunu tanımlayan isimdir (örneğin: "ViewDashboard", "EditUser").
    public string PermissionName { get; set; }

    // İzin açıklaması. İznin ne işe yaradığını veya hangi eylemi gerçekleştirdiğini açıklar.
    public string Description { get; set; }

    // Oluşturulma tarihi. İzin oluşturulduğu zaman otomatik olarak belirlenir.
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    // Güncellenme tarihi. İzin üzerinde herhangi bir değişiklik yapıldığında bu tarih güncellenir.
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

    // Rollerle ilişkili izinler. Bir izin, birçok rol tarafından paylaşılabilir.
    // Bu koleksiyon, izinlerin hangi rollerle ilişkili olduğunu tutar.
    public virtual ICollection<RolePermission> RolePermissions { get; set; }
}
