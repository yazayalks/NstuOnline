using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;
using NstuOnline.BFF.Application.Services;

namespace NstuOnline.BFF.Application.Features.Auth.GetToken;

public class GetTokenRequest : IRequest<GetTokenResponse>
{
    [Required]
    public string Username { get; set; }
        
    [Required]
    public string Password { get; set; }
}

public class GetTokenHandler : IRequestHandler<GetTokenRequest, GetTokenResponse>
{
    private readonly ITokenService _tokenService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetTokenHandler(
        ITokenService tokenService, 
        IHttpContextAccessor httpContextAccessor)
    {
        _tokenService = tokenService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<GetTokenResponse> Handle(
        GetTokenRequest request, 
        CancellationToken cancellationToken)
    {
        var ipAddress = _httpContextAccessor.HttpContext!.Connection.RemoteIpAddress!.MapToIPv4().ToString();

        return await _tokenService.Authenticate(request, ipAddress);
    }
}