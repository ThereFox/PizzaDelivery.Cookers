using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class ModificationToProductConfiguration : IEntityTypeConfiguration<ModificationToProductEntitys>
{
    public void Configure(EntityTypeBuilder<ModificationToProductEntitys> builder)
    {
        builder
            .HasKey(ex => ex.Id);
        builder
            .HasOne(ex => ex.ProductEntity)
            .WithMany(ex => ex.Modifications)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.ModificationId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(ex => ex.ModificationEntitys)
            .WithMany(ex => ex.UsedInCookingOrders)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.ModificationId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}