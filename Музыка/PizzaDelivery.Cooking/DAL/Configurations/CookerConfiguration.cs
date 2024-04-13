using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class CookerConfiguration : IEntityTypeConfiguration<Cookers>
{
    public void Configure(EntityTypeBuilder<Cookers> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.Name);
        
        builder
            .HasOne(ex => ex.Restoran)
            .WithMany(ex => ex.Workers)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.RestoraneId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasMany(ex => ex.CookingProducts)
            .WithOne(ex => ex.Cooker)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.CookerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}