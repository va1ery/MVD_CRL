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
    public class DetailsModel : PageModel
    {
        private readonly MVD_CRL.Models.MVD_CarlContext _context;

        public DetailsModel(MVD_CRL.Models.MVD_CarlContext context)
        {
            _context = context;
        }

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
    }
}
