using Luna.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Luna.Persistence.Data
{
    public static class AppDbSeed
    {
        static public IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
                if (db.Projects.Any()
                    && db.Technologys.Any()
                    && db.ProjectCategories.Any()
                    && db.Services.Any()
                    && db.Branches.Any()
                    && db.Users.Any()
                    && db.Roles.Any())
                    return app;

           

                #region AppRole
                List<AppRole> rList = new();

                rList.Add(new()
                {
                    Name = "SuperAdmin"
                });
                rList.Add(new()
                {
                    Name = "Admin"
                });
                rList.Add(new()
                {
                    Name = "Partner"
                });
                #endregion

                #region Branch
                List<Branch> bList = new();

                bList.Add(new()
                {
                    Name = "Backend Developer",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                bList.Add(new()
                {
                    Name = "FrontEnd Developer",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                bList.Add(new()
                {
                    Name = "Web Designer",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                #endregion

                #region AppUser
                List<AppUser> uList = new();

                uList.Add(new()
                {
                    UserName = "Ilham",
                    Email = "ilham@test.com",
                    EmailConfirmed = true,
                    BranchId = 1
                });
                uList.Add(new()
                {
                    UserName = "Eltun",
                    Email = "eltun@test.com",
                    EmailConfirmed = true,
                    BranchId = 1
                });
                uList.Add(new()
                {
                    UserName = "Agil",
                    Email = "Agil@test.com",
                    EmailConfirmed = true,
                    BranchId = 1
                });
                #endregion

                #region Service
                List<Service> sList = new();

                sList.Add(new()
                {
                    Name = "Web Development",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                sList.Add(new()
                {
                    Name = "Mobile Development",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                sList.Add(new()
                {
                    Name = "Wed Design",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                #endregion

                #region PC
                List<ProjectCategory> pcList = new();

                pcList.Add(new()
                {
                    Name = "IT",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                pcList.Add(new()
                {
                    Name = "Industry",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                pcList.Add(new()
                {
                    Name = "Health",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                #endregion

                #region Technology
                List<Technology> tList = new();

                tList.Add(new()
                {
                    Name = "C#",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    Icon = "test.jpg",
                });
                tList.Add(new()
                {
                    Name = "Node",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    Icon = "test.jpg",
                });
                tList.Add(new()
                {
                    Name = "Java",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    Icon = "test.jpg",
                });

                #endregion

                #region Project
                List<Project> pList = new();

                pList.Add(new()
                {
                    Name = "MeetUp",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    Url = "http://test.com",
                    ProjectCategoryId = 1,
                    Technologies = db.Technologys.Where(x => x.Id == 1).ToList(),
                    Image = "test.jpg",
                    ShortDescription = "It is a long established fact that a reader will be distracted by the readable content of a page",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."
                });
                pList.Add(new()
                {
                    Name = "OnBlog",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    Url = "http://test.com",
                    ProjectCategoryId = 1,
                    Technologies = db.Technologys.Where(x => x.Id == 2).ToList(),
                    Image = "test.jpg",
                    ShortDescription = "It is a long established fact that a reader will be distracted by the readable content of a page",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."
                });
                pList.Add(new()
                {
                    Name = "HealthPalace",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    Url = "http://test.com",
                    ProjectCategoryId = 3,
                    Technologies = db.Technologys.Where(x => x.Id == 3).ToList(),
                    Image = "test.jpg",
                    ShortDescription = "It is a long established fact that a reader will be distracted by the readable content of a page",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."
                });
                #endregion 

                db.ProjectCategories.AddRange(pcList);
                db.Technologys.AddRange(tList);
                db.Projects.AddRange(pList);
                db.Branches.AddRange(bList);
                db.Services.AddRange(sList);
                foreach (var user in uList)
                {
                    userManager.CreateAsync(user, "Pa$$w0rd");
                }
                foreach (var role in rList)
                {
                    roleManager.CreateAsync(role);
                }
                db.SaveChanges();
            }
            return app;
        }
    }
}