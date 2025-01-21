using System;

public class RolePermission
{
    // Benzersiz kimlik. Bu sınıf her iki varlık (Rol ve İzin) arasında bir ilişkiyi temsil ettiği için 
    // her ilişki için benzersiz bir GUID oluşturulur.
    public Guid Id { get; set; } = Guid.NewGuid();

    // İzin verilen rolün kimliği. Bu, rolün benzersiz kimliğidir ve hangi role izin verildiğini belirtir.
    public Guid RoleID { get; set; }

    // İzin kimliği. Bu, hangi iznin bu rol ile ilişkilendirildiğini belirtir.
    public Guid PermissionID { get; set; }

    // İzin verilen rol. Bu, `RoleID`'ye karşılık gelen rol nesnesini ifade eder.
    public virtual ApplicationRole Role { get; set; }

    // İzin. Bu, `PermissionID`'ye karşılık gelen izin nesnesini ifade eder.
    public virtual Permission Permission { get; set; }
}
