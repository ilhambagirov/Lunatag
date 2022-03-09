using System.Collections.Generic;

namespace Luna.Domain.Entities
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<AppUser> Partners { get; set; }
    }
}
