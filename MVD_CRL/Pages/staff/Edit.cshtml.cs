using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVD_CRL.Models;

namespace MVD_CRL.Pages.staff
{
    public class EditModel : PageModel
    {
        private readonly MVD_CRL.Models.MVD_CarlContext _context;

        public EditModel(MVD_CRL.Models.MVD_CarlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Сотрудники Сотрудники { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Сотрудники = await _context.Сотрудники
                .Include(с => с.КодДолжностиNavigation)
                .Include(с => с.КодЗванияNavigation).FirstOrDefaultAsync(m => m.КодСотрудника == id);

            if (Сотрудники == null)
            {
                return NotFound();
            }
           ViewData["КодДолжности"] = new SelectList(_context.Должности, "КодДолжности", "КодДолжности");
           ViewData["КодЗвания"] = new SelectList(_context.Звания, "КодЗвания", "КодЗвания");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Сотрудники).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!СотрудникиExists(Сотрудники.КодСотрудника))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool СотрудникиExists(int id)
        {
            return _context.Сотрудники.Any(e => e.КодСотрудника == id);
        }
    }
}
