using Luna.Application.EntitiesCQ.ProjectCategory.Interfaces;
using Luna.Application.Models.Dto.ProjectCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luna.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCategoryController : ControllerBase
    {
        private readonly IProjectCategoryService _projectCategoryService;

        public ProjectCategoryController(IProjectCategoryService projectCategoryService)
        {
            _projectCategoryService = projectCategoryService;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<Domain.Entities.ProjectCategory>>> Get()
        {
            return await _projectCategoryService.GetList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Entities.ProjectCategory>> Get(int id)
        {
            var result = await _projectCategoryService.Get(id);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(CreateProjectCategoryDto createProjectCategoryDto)
        {
            return await _projectCategoryService.Create(createProjectCategoryDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update([FromRoute] int id, [FromQuery] UpdateProjectCategoryDto updateProjectCategoryDto)
        {
            return await _projectCategoryService.Update(id, updateProjectCategoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _projectCategoryService.Delete(id);
            if (!result)
                return NotFound();

            return result; 
        }
    }
}
