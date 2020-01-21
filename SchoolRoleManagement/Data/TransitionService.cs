using GridMvc.Server;
using GridShared;
using GridShared.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Primitives;
using SchoolRoleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRoleManagement.Data
{
    
    public interface IRoleTransitionListService
    {
        Task<List<RoleTransition>> Get();
        Task<RoleTransition> Get(int id);
        Task<RoleTransition> Add(RoleTransition TeacherRole);
        Task<RoleTransition> Update(RoleTransition TeacherRole);
        Task<RoleTransition> Delete(int id);
    }
    public class RoleTransitionListService : IRoleTransitionListService
    {
        private readonly RoleDbContext _context;

        public RoleTransitionListService(RoleDbContext context)
        {
            _context = context;
        }
        public async Task<List<RoleTransition>> Get()
        {
            return await Task.FromResult( _context.Transitions.Include(t=> t.To).Include(t => t.From).ToList());
        }

        public async Task<RoleTransition> Get(int id)
        {
            var roleTransition = await _context.Transitions.FindAsync(new object[]{ id});
            return roleTransition;
        }

        public async Task<RoleTransition> Add(RoleTransition roleTransition)
        {
            _context.Transitions.Add(roleTransition);
            await _context.SaveChangesAsync();
            return roleTransition;
        }

        public async Task<RoleTransition> Update(RoleTransition roleTransition)
        {
            _context.Entry(roleTransition);
            await _context.SaveChangesAsync();
            return roleTransition;
        }

        public async Task<RoleTransition> Delete(int id)
        {
            var roleTransition = await _context.Transitions.FindAsync(id);
            _context.Transitions.Remove(roleTransition);
            await _context.SaveChangesAsync();
            return roleTransition;
        }
    }
}
