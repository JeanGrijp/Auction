using Auction.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Auction.API.Entities;

[Table("Items")]
public class ItemEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public Condition Condition { get; set; } 
    public decimal BasePrice { get; set; }

    public int AuctionId { get; set; }

    [JsonIgnore]
    public AuctionEntity Auction { get; set; }
}
