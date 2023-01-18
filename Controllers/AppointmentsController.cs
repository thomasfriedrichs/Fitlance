using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Fitlance.Data;
using Fitlance.Entities;
using System.Collections;

namespace Fitlance.Controllers;
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly FitlanceContext _context;

    public AppointmentsController(FitlanceContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
    {
        return await _context.Appointments.ToListAsync();
    }

    [HttpGet]
    [Route("GetUserAppointments/{id}")]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetUserAppointments(string? id)
    {
        var appointments = await _context.Appointments.Where(a => a.ClientId == id).ToListAsync();

        if (appointments == null)
        {
            return NotFound();
        }

        return appointments;
    }

    [HttpGet]
    [Route("GetTrainerAppointments/{id}")]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetTrainerAppointments(string id)
    {
        var appointments = await _context.Appointments.Where(a => a.TrainerId == id).ToListAsync();

        if (appointments == null)
        {
            return NotFound();
        }

        return appointments;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Appointment>> GetAppointment(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);

        if(appointment == null)
        {
            return NotFound();
        }

        return appointment;
    }


    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAppointment(int id, [FromBody] Appointment appointment)
    {
        try
        {   
            var existingAppointment = await _context.Appointments.FindAsync(id);

            if(existingAppointment == null)
            {
                return BadRequest("Appointment Not Found");
            }

            existingAppointment.AppointmentDate = appointment.AppointmentDate;
            existingAppointment.Address = appointment.Address;

            _context.Entry(existingAppointment).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AppointmentExists(id))
            {
                return NotFound("Not Found");
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AppointmentExists(int id)
    {
        return _context.Appointments.Any(e => e.Id == id);
    }
}
