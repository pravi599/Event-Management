using System;
using System.Collections.Generic;
using EventProject.Interfaces;
using EventProject.Models;
using EventProject.Models.DTOs;
using System.Linq;

namespace EventProject.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<int, Event> _eventRepository;

        public EventService(IRepository<int, Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public bool Add(EventDTO eventDTO)
        {
            try
            {
                // Map DTO to Entity
                var newEvent = new Event
                {
                    Title = eventDTO.Title,
                    Description = eventDTO.Description,
                    Date = eventDTO.Date,
                    Location = eventDTO.Location,
                    MaxAttendees = eventDTO.MaxAttendees,
                    RegistrationFee = eventDTO.RegistrationFee,
                    // Assuming Username is the organizer's name
                    Username = eventDTO.Username
                };

                // Add event to repository
                _eventRepository.Add(newEvent);

                // Return success
                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                // Handle exception
                return false;
            }
        }

        public IEnumerable<EventDTO> GetAllEvents()
        {
            try
            {
                // Get all events from repository
                var events = _eventRepository.GetAll();

                // Map entities to DTOs
                return events.Select(e => new EventDTO
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Date = e.Date,
                    Location = e.Location,
                    MaxAttendees = e.MaxAttendees,
                    RegistrationFee = e.RegistrationFee,
                    Username = e.Username
                });
            }
            catch (Exception ex)
            {
                // Log exception
                // Handle exception
                return null;
            }
        }

        public EventDTO GetEventById(int id)
        {
            try
            {
                // Get event by id from repository
                var eventEntity = _eventRepository.GetById(id);

                if (eventEntity == null)
                    return null;

                // Map entity to DTO
                return new EventDTO
                {
                    Id = eventEntity.Id,
                    Title = eventEntity.Title,
                    Description = eventEntity.Description,
                    Date = eventEntity.Date,
                    Location = eventEntity.Location,
                    MaxAttendees = eventEntity.MaxAttendees,
                    RegistrationFee = eventEntity.RegistrationFee,
                    Username = eventEntity.Username
                };
            }
            catch (Exception ex)
            {
                // Log exception
                // Handle exception
                return null;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                // Remove event from repository
                var removedEvent = _eventRepository.Delete(id);

                // Check if event was found and removed
                return removedEvent != null;
            }
            catch (Exception ex)
            {
                // Log exception
                // Handle exception
                return false;
            }
        }

        public EventDTO Update(EventDTO eventDTO)
        {
            try
            {
                // Map DTO to Entity
                var updatedEvent = new Event
                {
                    Id = eventDTO.Id,
                    Title = eventDTO.Title,
                    Description = eventDTO.Description,
                    Date = eventDTO.Date,
                    Location = eventDTO.Location,
                    MaxAttendees = eventDTO.MaxAttendees,
                    RegistrationFee = eventDTO.RegistrationFee,
                    // Assuming Username is the organizer's name
                    Username = eventDTO.Username
                };

                // Update event in repository
                var result = _eventRepository.Update(updatedEvent);

                // Map updated entity to DTO
                return new EventDTO
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    Date = result.Date,
                    Location = result.Location,
                    MaxAttendees = result.MaxAttendees,
                    RegistrationFee = result.RegistrationFee,
                    Username = result.Username
                };
            }
            catch (Exception ex)
            {
                // Log exception
                // Handle exception
                return null;
            }
        }
    }
}
