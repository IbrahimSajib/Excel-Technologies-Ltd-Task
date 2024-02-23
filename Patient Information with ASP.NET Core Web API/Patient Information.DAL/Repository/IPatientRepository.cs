using Patient_Information.BL.DTO;
using Patient_Information.BL.Models;

namespace Patient_Information.DAL.Repository
{
    public interface IPatientRepository
    {
        Task DeletePatientInformation(int id);
        Task<IEnumerable<Allergies>> GetAllergies();
        Task<IEnumerable<PatientDTO>> GetAllPatientInformation();
        Task<IEnumerable<Diseases>> GetDiseases();
        Task<IEnumerable<NCD>> GetNCD();
        Task<IEnumerable<Patient>> GetPatient();
        Task<PatientDTO> GetPatientInformationById(int id);
        Task PostPatientInformation(PatientDTO patientDTO);
        Task UpdatePatientInformation(PatientDTO patientDTO);
    }
}