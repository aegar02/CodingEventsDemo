using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        private EventDbContext _context;

        public EventsController(EventDbContext dbContext)
        {
            this._context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {

            List<Event> events = _context.Events.ToList();

            return View(events); //List<Event>
        }

        // Get: /<controller>/Add
        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        //POST: /<controller>/
        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    //Location = addEventViewModel.Location,
                    //NumberOfAttendees = addEventViewModel.NumberOfAttendees,
                    Type = addEventViewModel.Type
                };

                _context.Events.Add(newEvent); // This stages the data
                _context.SaveChanges(); // This actually saves the data in the DB


                return Redirect("/Events");
            }

            return View(addEventViewModel);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.events = _context.Events.ToList();


            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                Event theEvent = _context.Events.Find(eventId);
                _context.Events.Remove(theEvent);

            }

            _context.SaveChanges();

            return Redirect("/Events");

        }

        //[HttpGet]
        //[Route("/Events/Edit/{eventId}")]
        //public IActionResult Edit(int eventId)
        //{
        //    Event EditEvent = EventData.GetById(eventId);
        //    ViewBag.editEvent = EventData.GetById(eventId);
        //    ViewBag.title = $"Edit Event {EditEvent.Name} (id = {EditEvent.Id}";
        //    return View();
        //}

        //[HttpPost]
        //[Route("/Events/Edit")]
        //public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        //{
        //    Event EditEvent = EventData.GetById(eventId);
        //    EditEvent.Name = name;
        //    EditEvent.Description = description;

        //    return Redirect("/Events");
        //}
    }
}