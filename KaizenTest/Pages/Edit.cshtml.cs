using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaizenTest.Data;
using KaizenTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KaizenTest.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly ApplicationDbContext _context;

        public EditModel(ILogger<EditModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty(SupportsGet =true)]
        public Todo Todo { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Todo = _context.Todos.FirstOrDefault(x => x.ID == id);

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            var editTodo = _context.Todos.FirstOrDefault(x => x.ID == id);

            editTodo.todoDesc = Todo.todoDesc;
            editTodo.isCompleted = Todo.isCompleted;

            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
