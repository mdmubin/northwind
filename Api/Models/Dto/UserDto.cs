using System.ComponentModel.DataAnnotations;

namespace Api.Models.Dto;

public class UserCreationDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class UserAuthenticationDto
{
    [Required(ErrorMessage = "Cannot authenticate without username")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Cannot authenticate without password")]
    public string Password { get; set; }
}