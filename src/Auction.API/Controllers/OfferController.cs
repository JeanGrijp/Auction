using Auction.API.Comunication.Requests;
using Auction.API.Filters;
using Auction.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : AuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute]int itemId, 
        [FromBody] RequestCreateOfferJson  request,
        [FromServices] CreateOfferUseCase useCase
        )
    {

        var offerId = useCase.Execute(itemId, request);

        return Created(string.Empty, offerId);
    }
}
