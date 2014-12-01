using System.Data.Entity;

namespace GiftAidCalculator.Model
{
    public class EventSupplementContext : DbContext
    {
        public DbSet<EventSupplement> EventSupplements { get; set; }
    }
}