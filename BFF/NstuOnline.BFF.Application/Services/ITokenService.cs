using NstuOnline.BFF.Application.Features.Auth.GetToken;

namespace NstuOnline.BFF.Application.Services
{
    /// <summary>
    ///     A collection of token related services
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        ///     Validate the credentials entered when logging in.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        Task<GetTokenResponse> Authenticate(GetTokenRequest request, string ipAddress);
    }
}