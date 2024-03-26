using AuthProject.Common;

namespace AuthProject.Entities;

public class UserRole : EntityBase
{
    public int UserId { get; set; }
    public int  RoleId { get; set; }

    public User Users { get; set; } 
    public Role Roles { get; set; } 
}
