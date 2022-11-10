using Fitlance.Dtos;
using Fitlance.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fitlance.Services;

public class AuthenticationService : IAuthenticationService
{
  private readonly UserManager<User> _userManager;
  private readonly IConfiguration _configuration;

  public AuthenticationService(UserManager<User> userManager, IConfiguration configuration)
  {
    _userManager = userManager;
    _configuration = configuration;
  }

  public async Task<string> Register(RegisterRequest request)
  {
    var userByUsername = await _userManager.FindByNameAsync(request.Username);
    var userByEmail = await _userManager.FindByEmailAsync(request.Email);

    if (userByEmail is not null)
    {
      throw new ArgumentException($"User with {request.Email} already exists.");
    }
    if (userByUsername is not null)
    {
      throw new ArgumentException($"User with {request.Username} already exists.");
    }

    User user = new()
    {
      Email = request.Email,
      UserName = request.Username,
      SecurityStamp = Guid.NewGuid().ToString()
    };

    var result = await _userManager.CreateAsync(user, request.Password);

    if (request.Role == "User")
    {
      await _userManager.AddToRoleAsync(user, Role.User);
    }
    if (request.Role == "Trainer")
    {
      await _userManager.AddToRoleAsync(user, Role.Trainer);
    }

    if (!result.Succeeded)
    {
      throw new ArgumentException($"Unable to register user {request.Username} errors: {GetErrorsText(result.Errors)}");
    }

    return await Login(new LoginRequest { Email = request.Email, Password = request.Password });

  }

  public async Task<string> Login(LoginRequest request)
  {
    var user = await _userManager.FindByEmailAsync(request.Email);

    if (user is null)
    {
      user = await _userManager.FindByEmailAsync(request.Email);
    }

    if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
    {
      throw new ArgumentException($"Unable to authenticate user {request.Email}");
    }

    var authClaims = new List<Claim>
        {
            new (ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

    var userRoles = await _userManager.GetRolesAsync(user);

    if (userRoles is not null && userRoles.Any())
    {
       authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));
    }
   
    var token = GetToken(authClaims);
    
    return new JwtSecurityTokenHandler().WriteToken(token);
  }

  private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
  {
    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

    var token = new JwtSecurityToken(
        issuer: _configuration["JWT:ValidIssuer"],
        audience: _configuration["JWT:ValidAudience"],
        expires: DateTime.Now.AddHours(3),
        claims: authClaims,
        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

    return token;
  }

  private static string GetErrorsText(IEnumerable<IdentityError> errors)
  {
    return string.Join(", ", errors.Select(error => error.Description).ToArray());
  }
}
