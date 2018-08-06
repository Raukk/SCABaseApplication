using Microsoft.EntityFrameworkCore;
using SCABaseApplication.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCABaseApplication.DataAccess
{
    public class SchedulingDbContext : DbContext
    {
        public SchedulingDbContext()
        {

            //this.Database.EnsureCreated();
            //this.Database.Migrate();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=schedules.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FacilityDataModel>()
                .HasKey("Id");

            modelBuilder.Entity<TeamMemberDataModel>()
                .HasKey("Id");

            modelBuilder.Entity<TeamMemberDayScheduleDataModel>()
                .HasKey("Id");

            //modelBuilder.Entity<FacilityDataModel>()
            //  .HasKey(p => new { p.OrderID, p.ProductID });


        }

        public DbSet<FacilityDataModel> Facilities { get; set; }

        public DbSet<TeamMemberDataModel> TeamMember { get; set; }

        public DbSet<TeamMemberDayScheduleDataModel> TeamMemberDaySchedule { get; set; }

    }
}
