using Auction.API.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    public IActionResult GerCurrentAuction()
    {
        var useCase = new GetCurrentAuctionUseCase();
        var result =  useCase.Execute();
        return Ok(result);
    }
}
