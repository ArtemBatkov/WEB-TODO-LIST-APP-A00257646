using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TODO.Data;
using TODO.Models;

namespace TODO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDBContext context )
        {
            _logger = logger;
            this._context = context;
        }

        public async Task<ActionResult> Index()
        {
            //Task<ActionResult> provides returning data from db async
            //IQueryable is an object that provides remote control to database
            IQueryable<TodoList> items = from i in _context.ToDoList orderby i.Id select i;
            List<TodoList> todoList = await items.ToListAsync();
            return View(todoList);
        }











        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}