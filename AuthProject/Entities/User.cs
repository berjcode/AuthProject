using AuthProject.Common;
using System.Data;

namespace AuthProject.Entities;

public class User : EntityBase
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }

}
