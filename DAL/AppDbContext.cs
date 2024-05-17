using Medico.Models;
using Microsoft.EntityFrameworkCore;

namespace Medico.DAL
{
    public class AppDbContext:DbContext
    {
       

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

   
       public DbSet<Doctors> doctors { get; set; }
    }
}
