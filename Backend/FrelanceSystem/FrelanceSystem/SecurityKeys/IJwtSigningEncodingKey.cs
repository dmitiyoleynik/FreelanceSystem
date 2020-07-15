
using Microsoft.IdentityModel.Tokens;

namespace FrelanceSystem.SecurityKeys
{
    public interface IJwtSigningEncodingKey
    {
        string SigningAlgorithm { get; }
        SecurityKey GetKey();
    }
}
