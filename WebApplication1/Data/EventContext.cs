using EventLookupDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EventLookupDemo.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        public DbSet<Event> Event { get; set; }
    }
}
