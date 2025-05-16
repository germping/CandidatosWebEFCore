using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidatosWebApp.Data;
using CandidatosWebApp.Models;

namespace CandidatosWebApp.Pages.CandidateExperiences
{
    public class DeleteModel : PageModel
    {
        private readonly CandidatosWebApp.Data.CandidateContext _context;

        public DeleteModel(CandidatosWebApp.Data.CandidateContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CandidateExperience CandidateExperience { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateexperience = await _context.CandidateExperiences.FirstOrDefaultAsync(m => m.IdCandidateExperience == id);

            if (candidateexperience == null)
            {
                return NotFound();
            }
            else
            {
                CandidateExperience = candidateexperience;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateexperience = await _context.CandidateExperiences.FindAsync(id);
            if (candidateexperience != null)
            {
                CandidateExperience = candidateexperience;
                _context.CandidateExperiences.Remove(CandidateExperience);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
