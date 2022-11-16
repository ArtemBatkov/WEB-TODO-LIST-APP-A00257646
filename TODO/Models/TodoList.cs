using System.ComponentModel.DataAnnotations;
using TODO.Data;

namespace TODO.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsDone { get; set; }

        
        public DateTime? date { get; set; }

        //private readonly ApplicationDBContext _context;
        //public TodoList(ApplicationDBContext context)
        //{
        //    this._context = context;
        //}
    }
}
