using Microsoft.EntityFrameworkCore;
using backend.models;

namespace backend.persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        {

        }

        public DbSet<Message> Message { get; set; }
    }
}