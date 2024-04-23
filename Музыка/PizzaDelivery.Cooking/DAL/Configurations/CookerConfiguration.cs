using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class CookerConfiguration : IEntityTypeConfiguration<CookersEntity>
{
    public void Configure(EntityTypeBuilder<CookersEntity> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.FirstName)
            .IsRequired();
        
        
        builder
            .Property(ex => ex.MiddleName)
            .IsRequired();
        
        
        builder
            .Property(ex => ex.LastName)
            .IsRequired();
        
        builder
            .HasOne(ex => ex.WorkPlase)
            .WithMany(ex => ex.Workers)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.WorkPlaseId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasMany(ex => ex.CookedProducts)
            .WithOne(ex => ex.CookerEntity)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.CookerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}