using Blocks.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Blocks.AspNetCore;
using Auth.Application;

namespace Auth.API.Features.Login;

//[AllowAnonymous]
[HttpPost("/login")]
//[Tags("Auth")]
public class LoginEndpoint(UserManager<User> _userManager, SignInManager<User> _signInManager, TokenFactory _tokenFactory) 
    : Endpoint<LoginCommand, LoginResponse>
{
    public override async Task HandleAsync(LoginCommand command, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(command.Email);
        if (user == null)
            throw new BadRequestException($"User not found {command.Email}");

        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, command.Password, lockoutOnFailure: false); // turn lockoutOnFailure to true if you want to block the account after a few tries
        if (!signInResult.Succeeded)
            throw new BadRequestException($"Invalid credentials for {command.Email}");

        var userRoles = await _userManager.GetRolesAsync(user);

        // generate tokens
        var jwtToken = _tokenFactory.GenerateJWTToken(user.Id.ToString(), user.FullName, command.Email, userRoles, Array.Empty<Claim>());
        var refreshToken = _tokenFactory.GenerateRefreshToken(HttpContext.GetClientIpAddress());
        user.AddRefreshToken(refreshToken);

        await _userManager.UpdateAsync(user);

        await Send.OkAsync(new LoginResponse(command.Email, jwtToken, refreshToken.Token));
    }    
}
