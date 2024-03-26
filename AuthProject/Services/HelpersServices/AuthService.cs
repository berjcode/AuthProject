using AuthProject.Entities;
using AuthProject.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthProject.Services.HelpersServices;

public class AuthService : IAuthService
{

    private AppDbContext _dbContext;
    private IPasswordService _passwordService;
    private IConfiguration _configuration;

    public AuthService()
    {
        
    }
    public AuthService(AppDbContext dbContext, IPasswordService passwordService, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _passwordService = passwordService;
        _configuration = configuration;
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
            return GenerateToken();
        }

        return "Böyle bir Kullanıcı yok veya şifre yanlış";
    }

    private string GenerateToken()
    {

        var roles = new List<Claim>(){
           new Claim (ClaimTypes.Role,"Admin")
        };
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var Sectoken = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
          _configuration["Jwt:Issuer"],
          claims: roles,
          expires: DateTime.Now.AddMinutes(120),
          signingCredentials: credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

        return token;
}
}
