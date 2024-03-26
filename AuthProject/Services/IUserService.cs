using AuthProject.Entities;
using AuthProject.Models;

namespace AuthProject.Services;

public interface IUserService
{
   bool CreateUser(RequestRegisterModel requestRegisterModel);
}
