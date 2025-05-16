using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidatosWebApp.Data;
using CandidatosWebApp.Models;

namespace CandidatosWebApp.Pages.Candidates
{
    public class EditModel : PageModel
    {
        private readonly CandidatosWebApp.Data.CandidateContext _context;

        public EditModel(CandidatosWebApp.Data.CandidateContext context)
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

            var candidate =  await _context.Candidates.FirstOrDefaultAsync(m => m.IdCandidate == id);
            if (candidate == null)
            {
                return NotFound();
            }
            Candidate = candidate;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(Candidate.IdCandidate))
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

        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(e => e.IdCandidate == id);
        }
    }
}
