using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Entities;
using Api.Models.Dto;
using Api.Services.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services.DataServices;

public class AuthService
{
    private readonly IMapper _mapper;

    private readonly ILogService _logger;

    private readonly UserManager<User> _userManager;

    private readonly IConfiguration _configuration;

    private User _user;

    public AuthService(UserManager<User> userManager, IMapper mapper, ILogService logger,
        IConfiguration appConfig)
    {
        _userManager = userManager;
        _mapper = mapper;
        _logger = logger;
        _configuration = appConfig;
    }

    public async Task<IdentityResult> RegisterUser(UserCreationDto userForm)
    {
        var user = _mapper.Map<User>(userForm);

        var result = await _userManager.CreateAsync(user, userForm.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "user"); // requires the normalized name
        }

        return result;
    }

    public async Task<bool> ValidateUser(UserAuthenticationDto authReq)
    {
        _user = await _userManager.FindByNameAsync(authReq.UserName);
        var validUser = _user != null && await _userManager.CheckPasswordAsync(_user, authReq.Password);
        return validUser;
    }

    public async Task<string> GenerateToken()
    {
        var jwtConfig = _configuration.GetSection("JwtConfiguration");

        var key = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["JwtSecret"]!)),
            SecurityAlgorithms.HmacSha256
        );

        var roles = await _userManager.GetRolesAsync(_user);

        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Name, _user.UserName!));
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var tokenOpt = new JwtSecurityToken(
            issuer: jwtConfig["validIssuer"],
            audience: jwtConfig["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtConfig["ExpiresAfter"])),
            signingCredentials: key
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenOpt);
    }
}