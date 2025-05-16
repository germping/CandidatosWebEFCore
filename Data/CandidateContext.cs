using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CandidatosWebApp.Models;

namespace CandidatosWebApp.Data
{
    public class CandidateContext : DbContext
    {
        public CandidateContext (DbContextOptions<CandidateContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; } 
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().ToTable("Candidate");
            modelBuilder.Entity<CandidateExperience>().ToTable("CandidateExperience");
        }
    }
}
