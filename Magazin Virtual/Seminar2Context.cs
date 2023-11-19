using Microsoft.EntityFrameworkCore;
using Seminar_2.Models;

namespace Seminar_2
{
    public class Seminar2Context : DbContext
    {
        public Seminar2Context(DbContextOptions<Seminar2Context> options)
            : base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
