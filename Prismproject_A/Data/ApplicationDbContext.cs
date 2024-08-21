using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Prismproject_A.Models;
using Prismproject_A.Models.Entities;

namespace Prismproject_A.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            }

        public DbSet<Student> Students { get; set; }
        public virtual DbSet<FreezerDetails> FreezerDetails { get; set; }

        public virtual DbSet<BoxLocations> BoxLocations { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<SpecimenTypes> SpecimenTypes { get; set; }

        public virtual DbSet<BoxSubs> BoxSubs { get; set; }
        public virtual DbSet<BoxMain> BoxMain { get; set; } 

        public virtual DbSet<Report> Report { get; set; }

        public virtual DbSet<MRCmapping> MRCmapping { get; set; }

        public virtual DbSet<PasteErrors> PasteErrors { get; set; }

        public virtual DbSet<ImmerseSamples> ImmerseSamples { get; set; }
        public DbSet<Prismproject_A.Models.ZumbaSamples> ZumbaSamples { get; set; } = default!;

        



    }
}
