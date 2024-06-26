using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class StocksConfiguration : IEntityTypeConfiguration<RestoraneStocksDBEntity>
{
    public void Configure(EntityTypeBuilder<RestoraneStocksDBEntity> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.Weight)
            .IsRequired();

        builder
            .HasOne(ex => ex.Restorane)
            .WithMany(ex => ex.StocksList)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.RestoraneId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(ex => ex.Ingridient)
            .WithMany(ex => ex.StocksInRestorans)
            .HasForeignKey(ex => ex.RestoraneId)
            .HasPrincipalKey(ex => ex.Id)
            .OnDelete(DeleteBehavior.NoAction);

    }
}