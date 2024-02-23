using Microsoft.EntityFrameworkCore;
using Patient_Information.BL.DTO;
using Patient_Information.BL.Models;
using Patient_Information.DAL.Data;
using Newtonsoft.Json;

namespace Patient_Information.DAL.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDbContext _context;

        public PatientRepository(PatientDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Diseases>> GetDiseases()
        {
            return await _context.Diseases.ToListAsync();
        }
        public async Task<IEnumerable<Patient>> GetPatient()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<IEnumerable<NCD>> GetNCD()
        {
            return await _context.NCDs.ToListAsync();
        }

        public async Task<IEnumerable<Allergies>> GetAllergies()
        {
            return await _context.Allergies.ToListAsync();
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatientInformation()
        {
            List<PatientDTO> PatientInfo = new List<PatientDTO>();

            var allPatients = _context.Patients.ToList();
            foreach (var patient in allPatients)
            {
                var nCDList = _context.NCD_Details.Where(x => x.PatientId == patient.PatientId).Select(x => new NCD { NCDId = x.NCDId }).ToList();
                var allergiesList = _context.AllergiesDetails.Where(x => x.PatientId == patient.PatientId).Select(x => new Allergies { AllergiesId = x.AllergiesId }).ToList();

                PatientInfo.Add(new PatientDTO
                {
                    PatientId = patient.PatientId,
                    PatientName = patient.PatientName,
                    DiseasesId = patient.DiseasesId,
                    Epilepsy = patient.Epilepsy,
                    NCDList = nCDList.ToArray(),
                    AllergiesList = allergiesList.ToArray()
                });
            }
            return PatientInfo;
        }

        public async Task<PatientDTO> GetPatientInformationById(int id)
        {
            Patient patient = await _context.Patients.FindAsync(id);
            NCD[] nCDList = _context.NCD_Details.Where(x => x.PatientId == patient.PatientId).Select(x => new NCD { NCDId = x.NCDId }).ToArray();
            Allergies[] allergiesList = _context.AllergiesDetails.Where(x => x.PatientId == patient.PatientId).Select(x => new Allergies { AllergiesId = x.AllergiesId }).ToArray();

            PatientDTO patientInfo = new PatientDTO
            {
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                DiseasesId = patient.DiseasesId,
                Epilepsy = patient.Epilepsy,
                NCDList = nCDList,
                AllergiesList = allergiesList
            };

            return patientInfo;
        }


        //For Insert
        public async Task PostPatientInformation(PatientDTO patientDTO)
        {

            var nCdList = JsonConvert.DeserializeObject<NCD[]>(patientDTO.NCDStringify);
            var allergiesList = JsonConvert.DeserializeObject<Allergies[]>(patientDTO.AllergiesStringify);

            Patient patient = new Patient
            {
                PatientName = patientDTO.PatientName,
                DiseasesId = patientDTO.DiseasesId,
                Epilepsy = patientDTO.Epilepsy,
            };

            foreach (var item in nCdList)
            {
                var nCD_Details = new NCD_Details
                {
                    Patient = patient,
                    PatientId = patient.PatientId,
                    NCDId = item.NCDId
                };
                _context.NCD_Details.Add(nCD_Details);
            }

            foreach (var item in allergiesList)
            {
                var allergiesDetails = new AllergiesDetails
                {
                    Patient = patient,
                    PatientId = patient.PatientId,
                    AllergiesId = item.AllergiesId
                };
                _context.AllergiesDetails.Add(allergiesDetails);
            }

            await _context.SaveChangesAsync();
        }


        //For Update
        public async Task UpdatePatientInformation(PatientDTO patientDTO)
        {

            var nCDList = JsonConvert.DeserializeObject<NCD[]>(patientDTO.NCDStringify);
            var allergiesList = JsonConvert.DeserializeObject<Allergies[]>(patientDTO.AllergiesStringify);

            Patient patient = _context.Patients.Find(patientDTO.PatientId);
            patient.PatientName = patientDTO.PatientName;
            patient.DiseasesId = patientDTO.DiseasesId;
            patient.Epilepsy = patientDTO.Epilepsy;

            //Delete existing NCD
            var existingNCD = _context.NCD_Details.Where(x => x.PatientId == patient.PatientId).ToList();
            foreach (var item in existingNCD)
            {
                _context.NCD_Details.Remove(item);
            }
            //Add newly added NCD
            foreach (var item in nCDList)
            {
                var nCD_Details = new NCD_Details
                {
                    PatientId = patient.PatientId,
                    NCDId = item.NCDId
                };
                _context.NCD_Details.Add(nCD_Details);
            }

            //Delete existing Allergies
            var existingAllergies = _context.AllergiesDetails.Where(x => x.PatientId == patient.PatientId).ToList();
            foreach (var item in existingAllergies)
            {
                _context.AllergiesDetails.Remove(item);
            }
            //Add newly added Allergies
            foreach (var item in allergiesList)
            {
                var allergiesDetails = new AllergiesDetails
                {
                    PatientId = patient.PatientId,
                    AllergiesId = item.AllergiesId
                };
                _context.AllergiesDetails.Add(allergiesDetails);
            }

            _context.Entry(patient).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        //For Delete
        public async Task DeletePatientInformation(int id)
        {

            Patient patient = _context.Patients.Find(id);

            var existingNCD = _context.NCD_Details.Where(x => x.PatientId == patient.PatientId).ToList();
            foreach (var item in existingNCD)
            {
                _context.NCD_Details.Remove(item);
            }

            var existingAllergies = _context.AllergiesDetails.Where(x => x.PatientId == patient.PatientId).ToList();
            foreach (var item in existingAllergies)
            {
                _context.AllergiesDetails.Remove(item);
            }

            _context.Entry(patient).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

        }

    }
}