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

namespace CandidatosWebApp.Pages.CandidateExperiences
{
    public class EditModel : CandidateNamePageModel
    {
        private readonly CandidatosWebApp.Data.CandidateContext _context;

        public EditModel(CandidatosWebApp.Data.CandidateContext context)
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

            var candidateexperience =  await _context.CandidateExperiences.FirstOrDefaultAsync(m => m.IdCandidateExperience == id);
            if (candidateexperience == null)
            {
                return NotFound();
            }
            CandidateExperience = candidateexperience;

            PopulateCandidatesDropDownList(_context, CandidateExperience.IdCandidate);
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

            _context.Attach(CandidateExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExperienceExists(CandidateExperience.IdCandidateExperience))
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

        private bool CandidateExperienceExists(int id)
        {
            return _context.CandidateExperiences.Any(e => e.IdCandidateExperience == id);
        }
    }
}
