using AutoMapper;
using Luna.Application.EntitiesCQ.ProjectCategory.Interfaces;
using Luna.Application.Models.Dto.ProjectCategory;
using Luna.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luna.Application.EntitiesCQ.ProjectCategory.Services
{
    public class ProjectCategoryService : IProjectCategoryService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProjectCategoryService(AppDbContext appDbContext, IMapper mapper)
        {
            _dbContext = appDbContext;
            _mapper = mapper;
        }

       

        public async Task<Domain.Entities.ProjectCategory> Get(int id)
        {
            var pc = await _dbContext.ProjectCategories.FirstOrDefaultAsync(x => x.Id == id && x.DeletedDate == null);
            if (pc == null)
                return null;

            return pc;
        }

        public async Task<List<Domain.Entities.ProjectCategory>> GetList()
        {
            return await _dbContext.ProjectCategories.Where(x=>x.DeletedDate == null).ToListAsync();
        }


        public  async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> Create(CreateProjectCategoryDto command)
        {
            var pc = _mapper.Map<Domain.Entities.ProjectCategory>(command);
            pc.CreatedDate = DateTime.Now;
            pc.IsActive = true;

            await _dbContext.ProjectCategories.AddAsync(pc);
            return await SaveAsync();
        }

        public async Task<bool> Update(int id, UpdateProjectCategoryDto command)
        {
            var pc = await _dbContext.ProjectCategories.FindAsync(id);

            if (pc == null)
                return false;

            pc = _mapper.Map(command, pc);
            pc.UpdateDate = DateTime.Now;

            _dbContext.ProjectCategories.Update(pc);
            return await SaveAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var pc = await _dbContext.ProjectCategories.FirstOrDefaultAsync(x=>x.Id == id && x.DeletedDate == null);

            if (pc == null)
                return false;

            pc.DeletedDate = DateTime.Now;
            pc.IsActive = false;
            return await SaveAsync();
        }
    }
}
