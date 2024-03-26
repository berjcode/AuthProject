using AuthProject.Common;

namespace AuthProject.Entities;

public class Role : EntityBase
{
    public string Name { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}
