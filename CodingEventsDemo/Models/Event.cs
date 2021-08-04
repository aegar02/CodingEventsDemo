using System;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Models
{
    public class Event
    {
        //private static int _nextId = 1;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        //public string Location { get; set; }
        //public int NumberOfAttendees { get; set;
        public EventType Type { get; set; }

        public Event()
        {
            //this.Id = _nextId;

            //_nextId++;
        }

    //public Event(string name, string description, string contactEmail, string location, int numberOfAttendees)
    //   : this()
    //{
    //    this.Name = name;
    //    this.Description = description;
    //    this.ContactEmail = contactEmail;
    //    this.Location = Location;
    //    this.NumberOfAttendees = NumberOfAttendees;

    //}

    public Event(string name, string description, string contactEmail)
        //: this()
    {
        Name = name;
        Description = description;
        ContactEmail = contactEmail;
    }

    public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}