using Microsoft.AspNetCore.Identity;

namespace WellnessTracker.Services;

public class CurrentUserState
{
    public IdentityUser? User { get; private set; }

    public bool IsAuthenticated => User != null;

    public event Action? OnChange;

    public void SetUser(IdentityUser? user)
    {
        User = user;
        OnChange?.Invoke();
    }
}
