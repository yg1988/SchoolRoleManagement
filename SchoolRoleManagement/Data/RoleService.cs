using GridMvc.Server;
using GridShared;
using GridShared.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Primitives;
using SchoolRoleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRoleManagement.Data
{
    
    public interface ITeacherRoleListService
    {
        Task<List<TeacherRole>> Get();
        Task<TeacherRole> Get(int id);
        Task<TeacherRole> Add(TeacherRole TeacherRole);
        Task<TeacherRole> Update(TeacherRole TeacherRole);
        Task<TeacherRole> Delete(int id);
    }
    public class TeacherRoleListService : ITeacherRoleListService
    {
        private readonly RoleDbContext _context;

        public TeacherRoleListService(RoleDbContext context)
        {
            _context = context;
        }
        public async Task<List<TeacherRole>> Get()
        {
            return await Task.FromResult( _context.Roles.ToList());
        }

        public async Task<TeacherRole> Get(int id)
        {
            var TeacherRole = await _context.Roles.FindAsync(new object[]{ id});
            return TeacherRole;
        }

        public async Task<TeacherRole> Add(TeacherRole TeacherRole)
        {
            _context.Roles.Add(TeacherRole);
            await _context.SaveChangesAsync();
            return TeacherRole;
        }

        public async Task<TeacherRole> Update(TeacherRole TeacherRole)
        {
            _context.Entry(TeacherRole);
            await _context.SaveChangesAsync();
            return TeacherRole;
        }

        public async Task<TeacherRole> Delete(int id)
        {
            var TeacherRole = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(TeacherRole);
            await _context.SaveChangesAsync();
            return TeacherRole;
        }
    }
}
