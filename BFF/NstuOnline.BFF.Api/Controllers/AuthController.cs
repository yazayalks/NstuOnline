using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.BFF.Application.Features.Auth.GetToken;
using NstuOnline.BFF.Application.Features.Registration;

namespace NstuOnline.BFF.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public Task<GetTokenResponse> AuthenticateAsync(
            [FromBody] GetTokenRequest request,
            CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }

        [HttpPost("registration")]
        public Task<IActionResult> Registration(
            [FromBody] RegistrationRequest request,
            CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }
    }
}