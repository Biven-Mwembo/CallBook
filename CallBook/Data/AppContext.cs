using CallBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CallBook.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contacts> contacts { get; set; }
    }
}
