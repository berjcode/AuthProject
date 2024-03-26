using AuthProject.Models;

namespace AuthProject.Services.HelpersServices;

public interface IPasswordService
{
    PasswordDto HashPassword(string password);
    bool VerifyPassword(string password, string salt, string hashedPassword);

}
