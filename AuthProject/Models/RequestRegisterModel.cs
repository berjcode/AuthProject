using System.ComponentModel.DataAnnotations;

namespace AuthProject.Models;

public class RequestRegisterModel
{
    [Required]  //DataAnnotations
    [MinLength(5)]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    [MinLength(10)]
    public string Email { get; set; }
    [Required]
    [MinLength(3)]
    public string Password { get; set; }
}
