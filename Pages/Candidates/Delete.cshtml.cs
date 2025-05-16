using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidatosWebApp.Data;
using CandidatosWebApp.Models;

namespace CandidatosWebApp.Pages.Candidates
{
    public class DeleteModel : PageModel
    {
        private readonly CandidatosWebApp.Data.CandidateContext _context;

        public DeleteModel(CandidatosWebApp.Data.CandidateContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Candidate Candidate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates.FirstOrDefaultAsync(m => m.IdCandidate == id);

            if (candidate == null)
            {
                return NotFound();
            }
            else
            {
                Candidate = candidate;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                Candidate = candidate;
                _context.Candidates.Remove(Candidate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
