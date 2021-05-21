using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVD_CRL.Models;

namespace MVD_CRL.Pages.staff
{
    public class CreateModel : PageModel
    {
        private readonly MVD_CRL.Models.MVD_CarlContext _context;

        public CreateModel(MVD_CRL.Models.MVD_CarlContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["КодДолжности"] = new SelectList(_context.Должности, "КодДолжности", "КодДолжности");
        ViewData["КодЗвания"] = new SelectList(_context.Звания, "КодЗвания", "КодЗвания");
            return Page();
        }

        [BindProperty]
        public Сотрудники Сотрудники { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Сотрудники.Add(Сотрудники);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
