using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NstuOnline.BFF.Domain.Entity;

namespace NstuOnline.BFF.Application.Features.Registration;

public class RegistrationRequest : IRequest<IActionResult>
{
    public string Email { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string ReturnUrl { get; set; }
}

public class RegistrationHandler : IRequestHandler<RegistrationRequest, IActionResult>
{
    private readonly UserManager<User> _userManager;

    public RegistrationHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Handle(RegistrationRequest request, CancellationToken cancellationToken)
    {
        var newUser = new User()
        {
            Email = request.Email,
            UserName = request.UserName,
        };

        var result = await _userManager.CreateAsync(newUser, request.Password);

        if (result.Succeeded)
        {
            return new RedirectResult(request.ReturnUrl);
        }

        return new BadRequestResult();
    }
}