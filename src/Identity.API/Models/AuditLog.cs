using System;

public class AuditLog
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } // İşlemi yapan kullanıcı
    public string Action { get; set; } // Gerçekleştirilen işlem
    public DateTime Timestamp { get; set; } = DateTime.UtcNow; // İşlem tarihi
    public string Details { get; set; } // İşlemin detayları
}