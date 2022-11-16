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
        private readonly ApplicationDBContext context;
        public HomeController(ILogger<HomeController> logger, ApplicationDBContext context )
        {
            _logger = logger;
            this.context = context;
        }

        //MainPage where you can see all Notes
        public async Task<ActionResult> Index()
        {
            //Task<ActionResult> provides returning data from db async
            //IQueryable is an object that provides remote control to database
            IQueryable<TodoList> items = from i in context.ToDoList orderby i.Id select i;
            List<TodoList> todoList = await items.ToListAsync();
            return View(todoList);
        }


        //Create new note - button
        public IActionResult Create()
        {
            return View();
        }


        //Create new note - button -- post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TodoList item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();
                TempData["Success"] = "The item has been added!";
                return RedirectToAction("Index");
            }
            return View(item);
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