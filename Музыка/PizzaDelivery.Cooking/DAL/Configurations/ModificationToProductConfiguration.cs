using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class ModificationToProductConfiguration : IEntityTypeConfiguration<ModificationToProduct>
{
    public void Configure(EntityTypeBuilder<ModificationToProduct> builder)
    {
        builder
            .HasKey(ex => ex.Id);
        builder
            .HasOne(ex => ex.Product)
            .WithMany(ex => ex.Modifications)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.ModificationId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(ex => ex.Modification)
            .WithMany(ex => ex.UsedInCookingOrders)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.ModificationId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}