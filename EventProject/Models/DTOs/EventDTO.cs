﻿namespace EventProject.Models.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int MaxAttendees { get; set; }
        public float RegistrationFee { get; set; }
        public string Username { get; set; }
    }
}
