using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CompanyName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.TaxNumber)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(c => c.TradeRegistryNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Description)
            .HasMaxLength(500);

        builder.Property(c => c.Address)
            .HasMaxLength(300);

        builder.Property(c => c.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.District)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.PostalCode)
            .HasMaxLength(5);

        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(13);

        builder.Property(c => c.Email)
            .HasMaxLength(200);

        builder.Property(c => c.WebsiteUrl)
            .HasMaxLength(200);

        builder.Property(c => c.CompanyManager)
            .HasMaxLength(200);

        builder.Property(c => c.IndustryType)
            .HasMaxLength(100);

        builder.Property(c => c.LegalRepresentative)
            .HasMaxLength(200);

        builder.Property(c => c.EstablishedDate)
            .IsRequired();

        builder.Property(c => c.CreatedDate)
            .IsRequired();

        builder.Property(c => c.UpdatedDate)
            .IsRequired();

        builder.Property(c => c.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.HasIndex(c => c.CompanyName)
            .IsUnique();

        builder.HasIndex(c => c.TaxNumber)
            .IsUnique();

        builder.HasMany(c => c.Users)
            .WithOne()
            .HasForeignKey("CompanyId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Roles)
            .WithOne()
            .HasForeignKey("CompanyId")
            .OnDelete(DeleteBehavior.Cascade);

        // Table Mapping
        builder.ToTable("Companies");
    }
}
