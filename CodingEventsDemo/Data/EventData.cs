using System;
using System.Collections.Generic;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.Data
{
    public class EventData
    {
        //Store events
        private static Dictionary<int, Event> _events = new Dictionary<int, Event>();

        // GetAll - retrieve the events
        public static IEnumerable<Event> GetAll()
        {
            return _events.Values;
        }

        // Add events
        public static void Add(Event newEvent)
        {
            _events.Add(newEvent.Id, newEvent);
        }

        // Remove an event
        public static void Remove(int id)
        {
            _events.Remove(id);
        }

        // GetById - retrieve a single event
        public static Event GetById(int id)
        {
            return _events[id];
        }
    }
}