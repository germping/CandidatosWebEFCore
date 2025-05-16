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
    public class DetailsModel : PageModel
    {
        private readonly CandidatosWebApp.Data.CandidateContext _context;

        public DetailsModel(CandidatosWebApp.Data.CandidateContext context)
        {
            _context = context;
        }

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
    }
}
