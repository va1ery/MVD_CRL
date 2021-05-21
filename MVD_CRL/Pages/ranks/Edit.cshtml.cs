using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVD_CRL.Models;

namespace MVD_CRL.Pages.ranks
{
    public class EditModel : PageModel
    {
        private readonly MVD_CRL.Models.MVD_CarlContext _context;

        public EditModel(MVD_CRL.Models.MVD_CarlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Звания Звания { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Звания = await _context.Звания.FirstOrDefaultAsync(m => m.КодЗвания == id);

            if (Звания == null)
            {
                return NotFound();
            }
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

            _context.Attach(Звания).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ЗванияExists(Звания.КодЗвания))
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

        private bool ЗванияExists(int id)
        {
            return _context.Звания.Any(e => e.КодЗвания == id);
        }
    }
}
