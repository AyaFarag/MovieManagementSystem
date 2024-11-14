using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Infrastructure.Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class AssignRepository : IAssignRepository
    {
        private readonly DBContextApplication _context;
        public AssignRepository(DBContextApplication context) 
        {
            _context = context;
        }

        public async Task AssignUserToRole(int roleId, int userId)
        {
            //var user = await _context.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == userId);
            //var role = await _context.Roles.FindAsync(roleId);

            //if (user != null && role != null && !user.Roles.Contains(role))
            //{
            //    user.Roles.Add(role);
            //    await _context.SaveChangesAsync();
            //}
        }

        public Task AssignRoleToPermission(int roleId, int permissionId)
        {
            throw new NotImplementedException();
        }

        public Task AssignUserToPermission(int permissionId, int userId)
        {
            throw new NotImplementedException();
        }

      

        public Task RevokeRolePermission(int roleId, int permissionId)
        {
            throw new NotImplementedException();
        }

        public Task RevokeUserPermission(int userId, int permissionId)
        {
            throw new NotImplementedException();
        }

        public async Task RevokeUserRole(int userId, int roleId)
        {
            //var user = await _context.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == userId);
            //var role = await _context.Roles.FindAsync(roleId);

            //if (user != null && role != null && user.Roles.Contains(role))
            //{
            //    user.Roles.Remove(role);
            //    await _context.SaveChangesAsync();
            //}
        }
    }
}
