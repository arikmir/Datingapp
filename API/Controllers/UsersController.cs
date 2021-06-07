using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        //GET- api/users/
        [HttpGet]
        [AllowAnonymous]

        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = _context.Users.ToListAsync();
            return await users;
        }
        //GET- api/users/getuser/
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

    }
}