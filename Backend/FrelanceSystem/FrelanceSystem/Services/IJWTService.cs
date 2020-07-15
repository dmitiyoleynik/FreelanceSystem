using FrelanceSystem.ViewModels;

namespace FrelanceSystem.Services
{
    public interface IJWTService
    {
        string CreateToken(string userId);
    }
}
