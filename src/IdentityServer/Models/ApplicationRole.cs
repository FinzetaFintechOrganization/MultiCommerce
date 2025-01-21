using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public class ApplicationRole : IdentityRole<Guid>
{
    // Açıklama: Bu sınıf, Asp.Net Core Identity'de bir rolü temsil eder. IdentityRole sınıfından türetilmiştir,
    // yani bu sınıf, kullanıcılar için oluşturulan rollerin özelliklerini içerir.
    
    // Açıklama: Rolün açıklaması. Bu alan, rolün amacını veya fonksiyonunu belirten bir metin içerebilir.
    public string Description { get; set; }

    // Açıklama: Rolün oluşturulma tarihi. Varsayılan olarak UTC zamanında, bu tarih oluşturulurken otomatik olarak set edilir.
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    // Açıklama: Rolde yapılan herhangi bir değişikliğin güncellenme tarihi. Varsayılan olarak UTC zamanında set edilir.
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

    // Açıklama: Rolün ait olduğu şirketin ID'si. Bu, bir şirketle ilişkilendirilmiş bir rol olduğunu belirtir.
    public Guid CompanyID { get; set; }

    // Açıklama: Bir şirketin, ona ait olan rollerle ilişkisi. Her rol bir şirkete ait olabilir, 
    // bu ilişkiyi temsil eden navigation property'dir.
    public virtual Company Company { get; set; }

    // Açıklama: Bu koleksiyon, rolün sahip olduğu izinlerin listesini tutar. 
    // Her role, bir veya daha fazla izin atanabilir.
    public virtual ICollection<RolePermission> RolePermissions { get; set; }
}
