using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.State)
            .IsRequired();
        builder
            .Property(ex => ex.Code)
            .IsRequired();
        builder
            .Property(ex => ex.OrderTime)
            .HasColumnType("timestamp")
            .IsRequired();

        builder
            .HasOne(ex => ex.Restoran)
            .WithMany(ex => ex.Orders)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.RestoraneId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(ex => ex.Elements)
            .WithOne(ex => ex.Order)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.OrderId)
            .OnDelete(DeleteBehavior.NoAction);


    }
}