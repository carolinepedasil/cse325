using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WellnessTracker.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly UserSession _session;

        public CustomAuthenticationStateProvider(UserSession session)
        {
            _session = session;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity;

            if (_session.IsAuthenticated && !string.IsNullOrEmpty(_session.UserId))
            {
                // User is logged in
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, _session.UserId!),
                    new Claim(ClaimTypes.Name, _session.Email ?? _session.UserId!)
                }, authenticationType: "BlazorAuth");
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var principal = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(principal));
        }

        public void NotifyUserAuthentication(IdentityUser user)
        {
            _session.SetUser(user);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void NotifyUserLogout()
        {
            _session.Clear();
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
