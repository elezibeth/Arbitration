using Arbitration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arbitration.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ConsumerClaimant> ConsumerClaimants { get; set; }
        public DbSet<CaseTheory> CaseTheories { get; set; }
        public DbSet<CaseTheme> CaseThemes { get; set; }
        public DbSet<FactualTheory> FactualTheories { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Phase> Phases { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                   new IdentityRole
                   {
                       Name = "CommercialClaimant",
                       NormalizedName = "COMMERCIALCLAIMANT",
                   });
        }
    }
}
