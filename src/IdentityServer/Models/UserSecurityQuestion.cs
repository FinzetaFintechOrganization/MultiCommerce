using System;
using IdentityServer.Models;

public class UserSecurityQuestion
{
    // Bu güvenlik sorusu kaydının benzersiz kimliği
    public Guid Id { get; set; } = Guid.NewGuid();
    
    // Bu güvenlik sorusunun hangi kullanıcıya ait olduğunu belirten kullanıcı kimliği
    public Guid UserID { get; set; }
    
    // Bu güvenlik sorusunun kimliğini belirten güvenlik sorusu kimliği
    public Guid SecurityQuestionID { get; set; }
    
    // Kullanıcının bu soruya verdiği yanıtın şifrelenmiş hali
    public string AnswerHash { get; set; }

    // Kullanıcıya ait bilgileri tutan navigation property
    public virtual ApplicationUser User { get; set; }

    // Bu güvenlik sorusuna ait bilgileri tutan navigation property
    public virtual SecurityQuestion SecurityQuestion { get; set; }
}
