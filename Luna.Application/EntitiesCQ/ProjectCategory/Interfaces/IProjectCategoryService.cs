using Luna.Application.Models.Dto.ProjectCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luna.Application.EntitiesCQ.ProjectCategory.Interfaces
{
    public interface IProjectCategoryService : IBaseService
    {
        Task<List<Domain.Entities.ProjectCategory>> GetList();
        Task<Domain.Entities.ProjectCategory> Get(int id);

        Task<bool> Create(CreateProjectCategoryDto command);
        Task<bool> Update(UpdateProjectCategoryDto command);
        Task<bool> Delete(int id);
        Task<bool> SaveAsync();
    }
}
