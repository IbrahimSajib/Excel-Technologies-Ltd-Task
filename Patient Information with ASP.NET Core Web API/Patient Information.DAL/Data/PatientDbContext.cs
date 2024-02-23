using Microsoft.EntityFrameworkCore;
using Patient_Information.BL.Models;

namespace Patient_Information.DAL.Data
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {
        }

        public DbSet<Diseases> Diseases { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<NCD> NCDs { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<NCD_Details> NCD_Details { get; set; }
        public DbSet<AllergiesDetails> AllergiesDetails { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedDiseases();
            modelBuilder.SeedNCD();
            modelBuilder.SeedAllergies();
            modelBuilder.SeedPatient();
            modelBuilder.SeedNCD_Details();
            modelBuilder.SeedAllergiesDetails();
        }


    }
}