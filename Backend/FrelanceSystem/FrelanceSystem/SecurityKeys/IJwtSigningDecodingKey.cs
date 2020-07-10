using Microsoft.IdentityModel.Tokens;

namespace FrelanceSystem.SecurityKeys
{
    public interface IJwtSigningDecodingKey
    {
        SecurityKey GetKey();
    }
}
