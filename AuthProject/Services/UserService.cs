using AuthProject.Entities;
using AuthProject.Models;

namespace AuthProject.Services;

public class UserService : IUserService
{
    private AppDbContext _context;

    public UserService()
    {
        
    }
    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public bool CreateUser(RequestRegisterModel requestRegisterModel)
    {
        var user = new User
        {
            Name = requestRegisterModel.Name,
            Email = requestRegisterModel.Email,
            Password = requestRegisterModel.Password
        };

        user.Salt = "1212";


       _context.Users.Add(user);

      var result =   _context.SaveChanges();

        if(result == 0)
        {
            return false;
        }

        return true;
    }
}
