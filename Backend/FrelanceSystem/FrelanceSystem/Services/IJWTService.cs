using FrelanceSystem.ViewModels;

namespace FrelanceSystem.Services
{
    public interface IJWTService
    {
        string CreateTocken(UserAuthData user);
    }
}
