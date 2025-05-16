using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidatosWebApp.Data;
using CandidatosWebApp.Models;
using CandidatosWebApp.Pages.CandidateExperiences;

namespace CandidatosWebApp.Pages.Candidates
{
    public class CreateModel : PageModel
    {
        private readonly CandidatosWebApp.Data.CandidateContext _context;

        public CreateModel(CandidatosWebApp.Data.CandidateContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Candidate = new Candidate { Name = "Germán Andrés", Surname="Pinilla Guzman", email="german.pinillag@gmail.com", BirthDate = DateTime.Now, InsertDate = DateTime.Now, ModifyDate = DateTime.Now};
            return Page();
        }

        [BindProperty]
        public Candidate Candidate { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCandidate = new Candidate();
            try
            {
                if (await TryUpdateModelAsync<Candidate>(
               emptyCandidate,
               "candidate",   // Prefix for form value.
               s => s.Name, s => s.Surname, s => s.BirthDate, s => s.email, s => s.InsertDate, s => s.ModifyDate))
                {
                    _context.Candidates.Add(emptyCandidate);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("./Index");
                }
            }
            catch(Exception e)
            {
                
            }
           

            return Page();
        }
    }
}
