using AutoMapper;
using Luna.Application.Models.Dto.ProjectCategory;
using Luna.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProjectCategoryDto, ProjectCategory>().ReverseMap();
        }
    }
}
