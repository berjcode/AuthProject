using AuthProject.Entities;
using AuthProject.Models;
using AuthProject.Services.HelpersServices;

namespace AuthProject.Services;

public class UserService : IUserService
{
    private AppDbContext _context;
    private IPasswordService _passwordService;

    public UserService()
    {
        
    }
    public UserService(AppDbContext context, IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    public bool CreateUser(RequestRegisterModel requestRegisterModel)
    {
        var ExistsUser =   _context.Users.FirstOrDefault(x=> x.Email == requestRegisterModel.Email);
      
        if(ExistsUser != null )
        {
            return false;
        }

        var passwordResult = _passwordService.HashPassword(requestRegisterModel.Password);
        var user = new User
        {
            Name = requestRegisterModel.Name,
            Email = requestRegisterModel.Email,
            Password = passwordResult.PasswordHash,
            Salt = passwordResult.Salt
        };

       _context.Users.Add(user);

      var result =   _context.SaveChanges();

        if(result == 0)
        {
            return false;
        }

        return true;
    }
}
