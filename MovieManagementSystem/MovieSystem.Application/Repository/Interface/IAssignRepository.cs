using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Repository.Interface
{
    public interface IAssignRepository
    {
        Task AssignUserToRole(int roleId, int userId);
        Task AssignUserToPermission(int permissionId, int userId);
        Task AssignRoleToPermission(int roleId, int permissionId);

        Task RevokeUserRole(int userId, int roleId);
        Task RevokeUserPermission(int userId, int permissionId);

        Task RevokeRolePermission(int roleId, int permissionId);
    }
}
