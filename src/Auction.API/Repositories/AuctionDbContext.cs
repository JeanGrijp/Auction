using Auction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories;

public class AuctionDbContext : DbContext
{
    public DbSet<AuctionEntity> Auctions { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<OfferEntity> Offers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\workspace\leilaoDbNLW.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuctionEntity>()

            .HasMany(auction => auction.Items)
            .WithOne(item => item.Auction).HasForeignKey(item => item.AuctionId);
    }
}
