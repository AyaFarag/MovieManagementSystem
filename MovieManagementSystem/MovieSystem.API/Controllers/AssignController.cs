using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignController : ControllerBase
    {
        // inject interface service
        [HttpPost("Assign/role/user")]
        public async Task<IActionResult> AssignUserRole()
        {
            return Ok();
        }
        [HttpPost("Assign/role/permission")]
        public async Task<IActionResult> AssignRolePermission()
        {
            return Ok();
        }
    }
}
