using UserApp_Blazor.Domain.Commons;

namespace UserApp_Blazor.Domain.Entities;

public class User : Auditable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string About { get; set; }
}