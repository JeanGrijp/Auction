using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.API.Entities;

[Table("Auctions")]
public class AuctionEntity
{


    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Starts { get; set; }
    public DateTime Ends { get; set; }

    public List<ItemEntity> Items { get; set; } = [];
}
