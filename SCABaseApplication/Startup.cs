using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCABaseApplication.DataAccess;
using SCABaseApplication.DataAccess.DataModels;
using SCABaseApplication.Models;
using System;

namespace SCABaseApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });


            using (var context = new SchedulingDbContext())
            {
                context.Database.EnsureDeleted();//UnComment out this line to recreate the DB
                context.Database.EnsureCreated();

                //Create dummy test Data
                var facility1 = new DataAccess.DataModels.FacilityDataModel()
                {
                    FacilityId = "123",
                    FacilityName = "test",
                    CreatedBy = "Me",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "MeToo",
                    ModifiedOn = DateTime.Now,
                    ResourceId = Guid.NewGuid(),
                    Status = DataAccess.DataModels.DataStatus.Active
                };
                context.Facilities.Add(facility1);
                context.Facilities.Add(new DataAccess.DataModels.FacilityDataModel()
                {
                    FacilityId = "321",
                    FacilityName = "another test",
                    CreatedBy = "Me",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "MeToo",
                    ModifiedOn = DateTime.Now,
                    ResourceId = Guid.NewGuid(),
                    Status = DataAccess.DataModels.DataStatus.Active
                });
                var bob = new DataAccess.DataModels.TeamMemberDataModel()
                {
                    TeammateName = "Bob 1",
                    TeammateType = "Bob",
                    CurrentFacility = facility1,
                    CreatedBy = "Me",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "MeToo",
                    ModifiedOn = DateTime.Now,
                    ResourceId = Guid.NewGuid(),
                    Status = DataAccess.DataModels.DataStatus.Active
                };
                context.TeamMember.Add(bob);

                context.TeamMember.Add(new DataAccess.DataModels.TeamMemberDataModel()
                {
                    TeammateName = "Bob 2",
                    TeammateType = "Bob",
                    CurrentFacility = facility1,
                    CreatedBy = "Me",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "MeToo",
                    ModifiedOn = DateTime.Now,
                    ResourceId = Guid.NewGuid(),
                    Status = DataAccess.DataModels.DataStatus.Active
                });

                context.TeamMemberDaySchedule.Add(new DataAccess.DataModels.TeamMemberDayScheduleDataModel()
                {
                    Date = new DateTime(2018,8,6),
                    Schedule = "Never",
                    TeamMember = bob,
                    CreatedBy = "Me",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "MeToo",
                    ModifiedOn = DateTime.Now,
                    ResourceId = Guid.NewGuid(),
                    Status = DataAccess.DataModels.DataStatus.Active
                });

                context.TeamMemberDaySchedule.Add(new DataAccess.DataModels.TeamMemberDayScheduleDataModel()
                {
                    Date = new DateTime(2018, 8, 7),
                    Schedule = "some",
                    TeamMember = bob,
                    CreatedBy = "Me",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "MeToo",
                    ModifiedOn = DateTime.Now,
                    ResourceId = Guid.NewGuid(),
                    Status = DataAccess.DataModels.DataStatus.Active
                });

                context.TeamMemberDaySchedule.Add(new DataAccess.DataModels.TeamMemberDayScheduleDataModel()
                {
                    Date = new DateTime(2018, 8, 9),
                    Schedule = "Off Duty",
                    TeamMember = bob,
                    CreatedBy = "Me",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "MeToo",
                    ModifiedOn = DateTime.Now,
                    ResourceId = Guid.NewGuid(),
                    Status = DataAccess.DataModels.DataStatus.Active
                });

                context.TeamMemberDaySchedule.Add(new DataAccess.DataModels.TeamMemberDayScheduleDataModel()
                {
                    Date = new DateTime(2018, 8, 13),
                    Schedule = "Next Week",
                    TeamMember = bob,
                    CreatedBy = "Me",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "MeToo",
                    ModifiedOn = DateTime.Now,
                    ResourceId = Guid.NewGuid(),
                    Status = DataAccess.DataModels.DataStatus.Active
                });

                context.SaveChanges();
            }

            // Yes this should be in its own file
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<FacilityDataModel, FacilityModel>();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
