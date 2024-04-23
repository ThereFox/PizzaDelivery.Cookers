using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class OrdersConfiguration : IEntityTypeConfiguration<OrdersEntitys>
{
    public void Configure(EntityTypeBuilder<OrdersEntitys> builder)
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
            .HasOne(ex => ex.RestoranDbEntity)
            .WithMany(ex => ex.Orders)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.RestoraneId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(ex => ex.Elements)
            .WithOne(ex => ex.OrderEntitys)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.OrderId)
            .OnDelete(DeleteBehavior.NoAction);


    }
}