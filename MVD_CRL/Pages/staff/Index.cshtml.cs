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
    public class IndexModel : PageModel
    {
        private readonly MVD_CRL.Models.MVD_CarlContext _context;

        public IndexModel(MVD_CRL.Models.MVD_CarlContext context)
        {
            _context = context;
        }

        public IList<Сотрудники> Сотрудники { get;set; }

        public async Task OnGetAsync()
        {
            Сотрудники = await _context.Сотрудники
                .Include(с => с.КодДолжностиNavigation)
                .Include(с => с.КодЗванияNavigation).ToListAsync();
        }
    }
}
