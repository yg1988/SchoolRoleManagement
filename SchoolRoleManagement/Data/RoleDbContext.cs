using Microsoft.EntityFrameworkCore;
using SchoolRoleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRoleManagement.Data
{
    public class RoleDbContext : DbContext
    {
        public DbSet<TeacherRole> Roles { get; set; }

        public DbSet<RoleTransition> Transitions { get; set; }

        //public RoleDbContext(DbContextOptions<RoleDbContext> options)
        //: base(options)
        //{ }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
                

            }

            base.OnModelCreating(modelbuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=master;Trusted_Connection=True;");
        }
    }
}
