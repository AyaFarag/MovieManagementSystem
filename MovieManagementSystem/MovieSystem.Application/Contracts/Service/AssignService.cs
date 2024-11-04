using MovieSystem.Application.Contracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Contracts.Service
{
    public class AssignService : IAssignService
    {
        // inject AssignRepository interface
        public Task AssignRoleToPermission(int roleId, int permissionId)
        {
            throw new NotImplementedException();
        }

        public Task AssignUserToPermission(int permissionId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task AssignUserToRole(int roleId, int userId)
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

        public Task RevokeUserRole(int userId, int roleId)
        {
            throw new NotImplementedException();
        }
    }
}
