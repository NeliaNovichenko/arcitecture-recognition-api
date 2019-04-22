using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ArchitectureRecognition.Services.Data.Entities;
using ArchitectureRecognition.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureRecognition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _appUserService;

        public UserController(IUserService appUserService)
        {
            _appUserService = appUserService ?? throw new ArgumentNullException(nameof(appUserService));
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentUserAsync()
        {
            string currentUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (currentUserId == null)
            {
                return NotFound();
            }

            User currentAppUser = await _appUserService.GetByIdAsync(currentUserId);

            return Ok(currentAppUser);
        }
    }
}