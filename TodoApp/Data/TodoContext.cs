using Microsoft.EntityFrameworkCore;
using TodoApp.Domain;

namespace TodoApp.Data
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> Items { get; set; }
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {

        }
    }
}
