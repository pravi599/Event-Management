using EventProject.Interfaces;
using EventProject.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public ActionResult<EventDTO> AddEvent(EventDTO eventDTO)
        {
            try
            {
                var addedEvent = _eventService.Add(eventDTO);
                if (addedEvent != null)
                {
                    return Ok(addedEvent);
                }
                return BadRequest("Failed to add event.");
            }
            catch (DbUpdateException)
            {
                return BadRequest("Duplicate event data.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDTO>> GetAllEvents()
        {
            try
            {
                var events = _eventService.GetAllEvents();
                if (events != null)
                {
                    return Ok(events);
                }
                return NotFound("No events found.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EventDTO> GetEventById(int id)
        {
            try
            {
                var eventDTO = _eventService.GetEventById(id);
                if (eventDTO != null)
                {
                    return Ok(eventDTO);
                }
                return NotFound($"Event with ID {id} not found.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<EventDTO> UpdateEvent(int id, EventDTO eventDTO)
        {
            try
            {
                eventDTO.Id = id;
                var updatedEvent = _eventService.Update(eventDTO);
                if (updatedEvent != null)
                {
                    return Ok(updatedEvent);
                }
                return NotFound($"Event with ID {id} not found.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEvent(int id)
        {
            try
            {
                var result = _eventService.Remove(id);
                if (result)
                {
                    return Ok($"Event with ID {id} has been deleted.");
                }
                return NotFound($"Event with ID {id} not found.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
