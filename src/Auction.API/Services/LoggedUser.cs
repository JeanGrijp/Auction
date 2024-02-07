using Auction.API.Entities;
using Auction.API.Repositories;

namespace Auction.API.Services;

public class LoggedUser
{

    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoggedUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public UserEntity User()
    {
        var repository = new AuctionDbContext();

        var token = TokenOnRquest();
        var email = FromBase64(token);

        return repository.Users
            .First(user => user.Email.Equals(email));
    }

    private string TokenOnRquest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();


        return authentication["Bearer ".Length..];
    }

    private string FromBase64(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
