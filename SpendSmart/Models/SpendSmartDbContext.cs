using Microsoft.EntityFrameworkCore;

namespace SpendSmart.Models
{
    public class SpendSmartDbContext : DbContext
    {
        //in here, all our information will be saved
        //one way to set a table. type <Expense>
        public DbSet<Expense> Expenses {  get; set; }

        //provides the DBcontext options
        public SpendSmartDbContext(DbContextOptions<SpendSmartDbContext> options)
            : base(options)
        {
            
        }
    }
}
