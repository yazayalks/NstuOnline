using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NstuOnline.BFF.Application.Features.Auth.GetToken;
using NstuOnline.BFF.Domain.Entity;

namespace NstuOnline.BFF.Application.Services.Token
{
    /// <inheritdoc cref="ITokenService" />
    public class TokenService : ITokenService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly Domain.Models.Token _token;
        private readonly HttpContext _httpContext;

        /// <inheritdoc cref="ITokenService" />
        public TokenService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptions<Domain.Models.Token> tokenOptions,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _token = tokenOptions.Value;
            _httpContext = httpContextAccessor.HttpContext;
        }

        /// <inheritdoc cref="ITokenService.Authenticate(GetTokenRequest, string)"/>
        public async Task<GetTokenResponse> Authenticate(GetTokenRequest request, string ipAddress)
        {
            if (await IsValidUser(request.Username, request.Password))
            {
                User user = await GetUserByName(request.Username);

                if (user != null)
                {
                    string role = (await _userManager.GetRolesAsync(user)).SingleOrDefault();
                    string jwtToken = await GenerateJwtToken(user);

                    await _userManager.UpdateAsync(user);

                    return new GetTokenResponse(user,
                        role,
                        jwtToken
                        //""//refreshToken.Token
                    );
                }
            }

            return null;
        }

        private async Task<bool> IsValidUser(string username, string password)
        {
            User user = await GetUserByName(username);

            if (user == null)
            {
                // Username or password was incorrect.
                return false;
            }

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, password, true, false);

            return signInResult.Succeeded;
        }

        private async Task<User> GetUserByName(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            //  string role = (await _userManager.GetRolesAsync(user)).SingleOrDefault();
            byte[] secret = Encoding.ASCII.GetBytes(_token.Secret);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Issuer = _token.Issuer,
                Audience = _token.Audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //new Claim("UserId", user.Id),
                    //new Claim("FullName", $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    //  new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_token.Expiry),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}