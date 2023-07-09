using Api.Models.Dto;
using Api.Models.ErrorModels;
using Api.Services.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IDataServiceManager _dataService;

    public AuthController(IDataServiceManager dataService)
    {
        _dataService = dataService;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Register([FromBody] UserCreationDto userForm)
    {
        if (userForm == null)
        {
            throw new BadRequestError("Invalid request for registration.");
        }

        var user = await _dataService.AuthService.RegisterUser(userForm);
        if (user.Succeeded)
        {
            return Created(nameof(Authenticate), user);
        }

        foreach (var error in user.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }

        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Authenticate([FromBody] UserAuthenticationDto authReq)
    {
        if (await _dataService.AuthService.ValidateUser(authReq))
        {
            return Ok(new { Token = await _dataService.AuthService.GenerateToken() });
        }

        return Unauthorized();
    }
}