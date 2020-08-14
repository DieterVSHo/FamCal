using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FamCal_backend.Models;
using FamCal_backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FamCal_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        public EventsController(IEventRepository context)
        {
            _eventRepository = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]     //afschermen methode

        public IEnumerable<Event> GetEvents()
        {
            return _eventRepository.GetAll();
        }


        // GET: api/Events/5
        /// <summary>
        /// Get the event with given id
        /// </summary>
        /// <param name="id">the id of the event</param>
        /// <returns>The event</returns>
        [HttpGet("{id}")]
        public ActionResult<Event> GetEvent(int id)
        {
            Event ev = _eventRepository.GetBy(id);
            if (ev == null) return NotFound();
            return ev;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Event> PostEvent(EventDTO ev)
        {
            Event evToCreate = new Event()
            {
                Title = ev.title,
                StartDate = ev.startDate,
                EndDate = ev.endDate,
/*                Owner = ev.owner
*/            };
            _eventRepository.Add(evToCreate);    
            _eventRepository.SaveChanges();
            return CreatedAtAction(nameof(GetEvent),
            new { id = evToCreate.Id }, evToCreate);
        }

        [HttpPut("{id}")]
        public IActionResult PutEvent(int id, Event ev)
        {
            if (id != ev.Id)
            {
                return BadRequest();
            }
            _eventRepository.Update(ev);
            _eventRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            Event ev = _eventRepository.GetBy(id);
            if (ev == null)
            {
                return NotFound();
            }
            _eventRepository.Delete(ev);
            _eventRepository.SaveChanges();
            return NoContent();
        }

    }
}
