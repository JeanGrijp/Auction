using Auction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories;

public class AuctionDbContext : DbContext
{
    public DbSet<AuctionEntity> Auctions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\workspace\leilaoDbNLW.db");
    }
}
 