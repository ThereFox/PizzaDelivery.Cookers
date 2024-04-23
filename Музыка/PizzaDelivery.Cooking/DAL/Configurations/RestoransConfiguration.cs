using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class RestoransConfiguration : IEntityTypeConfiguration<RestoransDBEntity>
{
    public void Configure(EntityTypeBuilder<RestoransDBEntity> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.Address)
            .IsRequired();
        
        builder
            .Property(ex => ex.StartWorkingTime)
            .HasColumnType("time")
            .IsRequired();
        
        builder
            .Property(ex => ex.StopWorkingTime)
            .HasColumnType("time")
            .IsRequired();

        builder
            .HasMany(ex => ex.Workers)
            .WithOne(ex => ex.WorkPlase)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.WorkPlaseId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasMany(ex => ex.Orders)
            .WithOne(ex => ex.RestoranDbEntity)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.RestoraneId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(ex => ex.StocksList)
            .WithOne(ex => ex.Restorane)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.RestoraneId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}