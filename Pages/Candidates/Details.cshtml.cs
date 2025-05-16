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
    public class DetailsModel : PageModel
    {
        private readonly CandidatosWebApp.Data.CandidateContext _context;

        public DetailsModel(CandidatosWebApp.Data.CandidateContext context)
        {
            _context = context;
        }

        public Candidate Candidate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var candidate = await _context.Candidates
                .Include(s => s.IdCandidate)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IdCandidate == id);*/

            Candidate = await _context.Candidates
            .Include(s => s.CandidateExperiences)
            //.ThenInclude(e => e.Course)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.IdCandidate == id);
            if (Candidate == null)
            {
                return NotFound();
            }
            else
            {
                Candidate = Candidate;
            }
            return Page();
        }
    }
}
