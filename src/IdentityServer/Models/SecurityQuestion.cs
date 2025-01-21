using System;

public class SecurityQuestion
{
    // Benzersiz kimlik. Her bir güvenlik sorusu için benzersiz bir GUID atanır.
    public Guid Id { get; set; } = Guid.NewGuid();

    // Güvenlik sorusunun metni. Kullanıcı tarafından seçilen güvenlik sorusu burada saklanır.
    public string Question { get; set; }

    // Güvenlik sorusunun cevabının hash değeri. Bu, güvenlik sorusunun yanıtını saklar, ancak doğrudan yanıtı tutmaz.
    // Cevaplar genellikle güvenlik amacıyla hash'lenir, böylece yanıtın kendisi veritabanında saklanmaz.
    public string AnswerHash { get; set; }
}
