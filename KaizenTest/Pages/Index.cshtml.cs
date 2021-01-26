using KaizenTest.Data;
using KaizenTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace KaizenTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext _context)
        {
            _logger = logger;
            this._context = _context;
        }

        [BindProperty(SupportsGet = true)]
        public Todo Todo { get; set; }

        public List<Todo> todoList { get; set; }

        public string loaderID { get; set; }

        public IActionResult OnGet()
        {
            todoList = _context.Todos.ToList();

            loaderID = "btnLoader";

            return Page();
        }

        public IActionResult OnPost()
        {
            Todo newTodo = new Todo
            {
                todoDesc = Todo.todoDesc,
                isCompleted = Todo.isCompleted
            };

            _context.Todos.Add(newTodo);

            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}