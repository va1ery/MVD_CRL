using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MVD_CRL.Models;

namespace MVD_CRL.Pages.staff
{
    public class DeleteModel : PageModel
    {
        private readonly MVD_CRL.Models.MVD_CarlContext _context;

        public DeleteModel(MVD_CRL.Models.MVD_CarlContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Сотрудники = await _context.Сотрудники.FindAsync(id);

            if (Сотрудники != null)
            {
                _context.Сотрудники.Remove(Сотрудники);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
