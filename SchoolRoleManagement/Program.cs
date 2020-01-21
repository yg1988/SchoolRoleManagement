using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SchoolRoleManagement.Data;
using SchoolRoleManagement.Models;

namespace SchoolRoleManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using (var db = new RoleDbContext())
            //{
            //    var blog = new TeacherRole { RoleName = "haha" };
            //    db.Roles.Add(blog);
            //    db.SaveChanges();
            //}
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
