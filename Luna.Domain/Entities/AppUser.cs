using Microsoft.AspNetCore.Identity;

namespace Luna.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
