using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidatosWebApp.Data;
using CandidatosWebApp.Models;

namespace CandidatosWebApp.Pages.CandidateExperiences
{
    public class CreateModel :CandidateNamePageModel
    {
        private readonly CandidatosWebApp.Data.CandidateContext _context;

        public CreateModel(CandidatosWebApp.Data.CandidateContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateCandidatesDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public CandidateExperience CandidateExperience { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyExperience = new CandidateExperience();

            if (await TryUpdateModelAsync<CandidateExperience>(
                 emptyExperience,
                 "candidateExperience",   // Prefix for form value.
                 s => s.IdCandidate, s => s.IdCandidateExperience, s => s.Job, s => s.Description, s => s.Company, s => s.Salary, s => s.BeginDate, s => s.EndDate, s => s.InsertDate, s => s.ModifyDate))
            {
                _context.CandidateExperiences.Add(emptyExperience);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

   
            PopulateCandidatesDropDownList(_context, emptyExperience.IdCandidateExperience);
            return Page();

        }
    }
}
