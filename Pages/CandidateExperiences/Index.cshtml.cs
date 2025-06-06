﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly CandidatosWebApp.Data.CandidateContext _context;

        public IndexModel(CandidatosWebApp.Data.CandidateContext context)
        {
            _context = context;
        }

        public IList<CandidateExperience> CandidateExperience { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CandidateExperience = await _context.CandidateExperiences.ToListAsync();
        }
    }
}
