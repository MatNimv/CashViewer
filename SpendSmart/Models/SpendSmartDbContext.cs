using Microsoft.EntityFrameworkCore;

namespace SpendSmart.Models
{
    public class SpendSmartDbContext : DbContext
    {
        //in here, all our information will be saved
        public DbSet<Expense> Expenses {  get; set; }

        public SpendSmartDbContext(DbContextOptions<SpendSmartDbContext> options)
            : base(options)
        {
            
        }
    }
}
