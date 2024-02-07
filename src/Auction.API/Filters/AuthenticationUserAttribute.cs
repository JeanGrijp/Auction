using Auction.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Auction.API.Filters;

public class AuthenticationUserAttribute: AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try 
        {
            var token = TokenOnRquest(context.HttpContext);
            var repository = new AuctionDbContext();
            var email = FromBase64(token);
            var exists = repository.Users.Any(user => user.Email.Equals(email));

            if (exists == false)
            {
                context.Result = new UnauthorizedObjectResult("Email not valid");
            }
        } 
        catch (Exception e)
        {
            context.Result = new UnauthorizedObjectResult(e.Message);
        }
    }

    private string TokenOnRquest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authentication) )
        {
           throw new Exception("Token not found");
        }

        return authentication["Bearer ".Length..];
    }

    private string FromBase64(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
