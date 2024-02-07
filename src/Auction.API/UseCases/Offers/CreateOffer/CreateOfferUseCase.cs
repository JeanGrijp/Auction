﻿using Auction.API.Comunication.Requests;
using Auction.API.Entities;
using Auction.API.Repositories;
using Auction.API.Services;

namespace Auction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{

    private readonly LoggedUser _loggedUser;

    public CreateOfferUseCase(LoggedUser loggedUser)
    {
        _loggedUser = loggedUser;
    }

    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var repository = new AuctionDbContext();
        var loggedUser = _loggedUser.User();
        var offer = new OfferEntity
        {
            CreatedOn = DateTime.Now,
            Price = request.Price,
            ItemId = itemId,
            UserId = loggedUser.Id,

        };
        repository.Offers.Add(offer);
        repository.SaveChanges();

        return offer.Id;
    }
}
