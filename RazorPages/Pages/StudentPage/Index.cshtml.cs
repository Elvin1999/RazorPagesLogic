using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.DATA;
using RazorPages.Entities;

namespace RazorPages.Pages.StudentPage
{
    public class IndexModel : PageModel
    {
        private readonly StudentDbContext _context;

        public IndexModel(StudentDbContext context)
        {
            _context = context;
        }
        public List<Student> Students { get; set; }
        public void OnGet(string s=null)
        {
            Students = string.IsNullOrEmpty(Search)
                ?_context.Students.ToList()
                : _context.Students.Where(st=>st.Name.Contains(Search)).ToList();
        }
        [BindProperty(SupportsGet =true)]
        public string Search { get; set; }

        [BindProperty]
        public Student Student { get; set; }
        public IActionResult OnPost()
        {
            _context.Students.Add(Student);
            _context.SaveChanges();
            return RedirectToPage("/StudentPage/Index");
        }
    }
}
