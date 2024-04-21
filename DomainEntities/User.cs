using Microsoft.AspNetCore.Identity;

namespace DomainEntities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
