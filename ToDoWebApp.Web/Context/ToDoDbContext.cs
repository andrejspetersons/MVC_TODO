using Microsoft.EntityFrameworkCore;
using ToDoWebApp.Web.Models;

namespace ToDoWebApp.Web.Context
{
    public class ToDoDbContext:DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext>options):base(options)
        {
            
        }
        
        public DbSet<ToDoItem> Todos { get; set; }
    }
}
