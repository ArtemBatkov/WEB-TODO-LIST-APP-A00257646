using Microsoft.EntityFrameworkCore;
using TODO.Models;

namespace TODO.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet <TodoList> ToDoList { get; set; }
        
        public ApplicationDBContext(DbContextOptions <ApplicationDBContext> options) : base(options)
        {
            
        }

    }
}
