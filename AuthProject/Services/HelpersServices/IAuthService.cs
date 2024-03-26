using AuthProject.Models;

namespace AuthProject.Services.HelpersServices;

public interface  IAuthService
{
    string UserLogin(RequestLoginModel requestLoginModel);
}
