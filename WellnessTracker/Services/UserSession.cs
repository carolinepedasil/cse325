using Microsoft.AspNetCore.Identity;

namespace WellnessTracker.Services
{
    public class UserSession
    {
        public string? UserId { get; private set; }
        public string? Email { get; private set; }

        public bool IsAuthenticated => !string.IsNullOrEmpty(UserId);

        public void SetUser(IdentityUser user)
        {
            UserId = user.Id;
            Email = user.Email;
        }

        public void Clear()
        {
            UserId = null;
            Email = null;
        }
    }
}
