using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventLookupDemo.Data;
using EventLookupDemo.Models;

namespace EventLookupDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventsController : Controller
    {
        private readonly EventContext _context;

        public EventsController(EventContext context)
        {
            _context = context;
        }

        // GET: Events
        [Route("~/api/GetEvents")]
        [HttpGet]
        public ICollection<Event> Index(string keyword = "")
        {
            var events = _context.Event.ToList();
            return events;
        }

        // GET: Events by keyword
        [Route("~/api/GetEventsByKeyword/{keyword:maxlength(20)}")]
        [HttpGet]
        public IQueryable<Event> search(string keyword = "")
        {
            var events = from e in _context.Event
                         where e.Description.Contains(keyword)
                         select e;

            return events;
        }

        // GET: Events/Details/5
        [HttpGet("{id}")]
        public Event Details(int? id)
        {
            var theEvent = _context.Event.SingleOrDefault(m => m.Id == id);

            return theEvent;
        }
    }
}
