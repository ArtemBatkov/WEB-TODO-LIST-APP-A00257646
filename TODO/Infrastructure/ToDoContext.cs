using Microsoft.EntityFrameworkCore;
using TODO.Models;

namespace TODO.Infrastructure
{
    public class ToDoContext:DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
        :base(options)
        {

        }


        public DbSet<TodoList> ToDoList { get; set; }
    }
}
