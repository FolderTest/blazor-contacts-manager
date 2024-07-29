using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Here you would typically check if the user is authenticated.
        // For example, you might check a token stored in local storage.
        var user = new ClaimsPrincipal(new ClaimsIdentity()); // Replace with actual user logic
        return Task.FromResult(new AuthenticationState(user));
    }

    public void NotifyAuthenticationStateChanged(ClaimsPrincipal user)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(user.Claims, "custom"));
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(authenticatedUser)));
    }
}