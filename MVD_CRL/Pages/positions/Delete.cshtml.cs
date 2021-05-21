using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MVD_CRL.Models;

namespace MVD_CRL.Pages.positions
{
    public class DeleteModel : PageModel
    {
        private readonly MVD_CRL.Models.MVD_CarlContext _context;

        public DeleteModel(MVD_CRL.Models.MVD_CarlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Должности Должности { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Должности = await _context.Должности.FirstOrDefaultAsync(m => m.КодДолжности == id);

            if (Должности == null)
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

            Должности = await _context.Должности.FindAsync(id);

            if (Должности != null)
            {
                _context.Должности.Remove(Должности);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
