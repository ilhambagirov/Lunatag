using System.Collections.Generic;

namespace Luna.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public int ProjectCategoryId { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
        public ICollection<Technology> Technologies { get; set; }
    }
}
