using Fitlance.Data;
using Fitlance.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Fitlance.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly FitlanceContext _context;

    private readonly UserManager<User> _userManager;

    public UsersController(FitlanceContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
       return await _context.Users.ToListAsync();
    }

    // GET: api/Users/FindTrainers
    [HttpGet]
    [Route("FindTrainers")]
    public async Task<ActionResult<IEnumerable<User>>> FindTrainers()
    {
        var trainers = await _userManager.GetUsersInRoleAsync("Trainer");

        return trainers.ToList();
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(string id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // PUT: api/User/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(string id, [FromBody] User user)
    {
        var account = _context.Users.Find(id);
        
        try
        {
            var entity = _context.Users.Single(e => e.Id == id);

            if (entity is null)
            {
                return BadRequest("User not Found");
            }

            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.City = user.City;
            entity.ZipCode = user.ZipCode;
            entity.Bio = user.Bio;

            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        

        return Content("Success");
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserExists(string id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}
