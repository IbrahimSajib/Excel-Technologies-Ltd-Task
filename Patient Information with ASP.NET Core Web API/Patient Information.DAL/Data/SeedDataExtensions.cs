using Microsoft.EntityFrameworkCore;
using Patient_Information.BL.Models;

namespace Patient_Information.DAL.Data
{
    public static class SeedDataExtensions
    {
        //Seed Diseases
        public static void SeedDiseases(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diseases>().HasData(
                new Diseases { DiseasesId = 1, DiseasesName = "Ischemic Heart Disease" },
                new Diseases { DiseasesId = 2, DiseasesName = "Stroke" },
                new Diseases { DiseasesId = 3, DiseasesName = "Influenza or Flu" },
                new Diseases { DiseasesId = 4, DiseasesName = "Pneumonia" },
                new Diseases { DiseasesId = 5, DiseasesName = "Alzheimer’s disease" },
                new Diseases { DiseasesId = 6, DiseasesName = "Arthritis" },
                new Diseases { DiseasesId = 7, DiseasesName = "Angina" },
                new Diseases { DiseasesId = 8, DiseasesName = "Anorexia nervosa" },
                new Diseases { DiseasesId = 9, DiseasesName = "Anxiety disorders" }
            );
        }
        
        //Seed NCD
        public static void SeedNCD(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NCD>().HasData(
                new NCD { NCDId=1,NCDName="Asthma"},
                new NCD { NCDId=2,NCDName="Cancer"},
                new NCD { NCDId=3,NCDName="Disorders of ear"},
                new NCD { NCDId=4,NCDName="Disorder of eye"},
                new NCD { NCDId=5,NCDName="Mental illness"},
                new NCD { NCDId=6,NCDName="Oral helth problems"}
            );
        }

        //Seed Allergies
        public static void SeedAllergies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergies>().HasData(
                new Allergies { AllergiesId=1,AllergiesName="Drugs - Penicillin"},
                new Allergies { AllergiesId=2,AllergiesName="Drusg - Others"},
                new Allergies { AllergiesId=3,AllergiesName="Animals"},
                new Allergies { AllergiesId=4,AllergiesName="Food"},
                new Allergies { AllergiesId=5,AllergiesName="Oniments"},
                new Allergies { AllergiesId=6,AllergiesName="Plant"},
                new Allergies { AllergiesId=7,AllergiesName="Sprays"},
                new Allergies { AllergiesId=8,AllergiesName="Others"},
                new Allergies { AllergiesId=9,AllergiesName="No Allergies"}
            );
        }

        //Seed Patient
        public static void SeedPatient(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId=1,PatientName="Lorem",DiseasesId=9,Epilepsy=Epilepsy.No},
                new Patient { PatientId=2,PatientName="Amet",DiseasesId=2,Epilepsy=Epilepsy.No}
            );
        }

        //Seed NCD_Details
        public static void SeedNCD_Details(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NCD_Details>().HasData(
                new NCD_Details { Id=1,PatientId=1,NCDId=3},
                new NCD_Details { Id=2,PatientId=1,NCDId=5},
                new NCD_Details { Id=3,PatientId=2,NCDId=4},
                new NCD_Details { Id=4,PatientId=2,NCDId=5}
            );
        }

        //Seed AllergiesDetails
        public static void SeedAllergiesDetails(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllergiesDetails>().HasData(
                new AllergiesDetails { Id=1,PatientId=1,AllergiesId=4},
                new AllergiesDetails { Id=2,PatientId=1,AllergiesId=7},
                new AllergiesDetails { Id=3,PatientId=2,AllergiesId=8}
            );
        }


    }
}