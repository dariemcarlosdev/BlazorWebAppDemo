using BlazingPizza.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.DAL
{
    public class PizzaStoreDemoContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<PizzaSpecial> Specials { get; set; }
    }
}
