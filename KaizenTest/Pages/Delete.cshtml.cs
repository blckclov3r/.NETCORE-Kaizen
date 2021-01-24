using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaizenTest.Data;
using KaizenTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KaizenTest.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext _context)
        {
            this._context = _context;
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

            if(Todo == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Todo = _context.Todos.Find(id);

            if(Todo != null)
            {
                _context.Todos.Remove(Todo);
                _context.SaveChanges();
            }


            return RedirectToPage("./Index");
        }


        //public void OnGet()
        //{


        //}


    }
}
