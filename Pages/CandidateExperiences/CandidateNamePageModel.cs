using CandidatosWebApp.Data;
using CandidatosWebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CandidatosWebApp.Pages.CandidateExperiences
{
    public class CandidateNamePageModel : PageModel
    {

        public SelectList CandidateNameSL { get; set; }

        public void PopulateCandidatesDropDownList(CandidateContext _context,
            object selectedCandidate = null)
        {
            var candidatesQuery = from d in _context.Candidates
                                   orderby d.Name // Sort by name.
                                   select d;

            CandidateNameSL = new SelectList(candidatesQuery.AsNoTracking(),
                nameof(Candidate.IdCandidate),
                nameof(Candidate.Name),
                selectedCandidate);
        }
    }
}

