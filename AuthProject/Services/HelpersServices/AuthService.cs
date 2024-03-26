using AuthProject.Models;

namespace AuthProject.Services.HelpersServices;

public class AuthService : IAuthService
{

    private AppDbContext _dbContext;
    private IPasswordService _passwordService;

    public AuthService()
    {
        
    }
    public AuthService(AppDbContext dbContext, IPasswordService passwordService)
    {
        _dbContext = dbContext;
        _passwordService = passwordService;
    }

    public string UserLogin(RequestLoginModel requestLoginModel)
    {

        var result = _dbContext.Users.FirstOrDefault(x => x.Email == requestLoginModel.Email );
        
        if( result == null)
        {
            return "Böyle bir Kullanıcı";
        }

        if (_passwordService.VerifyPassword(requestLoginModel.Password, result.Salt, result.Password) == true)
        {
            return "token";
        }

        return "Böyle bir Kullanıcı yok veya şifre yanlış";
    }
}
