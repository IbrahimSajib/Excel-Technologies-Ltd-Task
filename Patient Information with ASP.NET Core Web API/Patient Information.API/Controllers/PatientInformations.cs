using Microsoft.AspNetCore.Mvc;
using Patient_Information.BL.DTO;
using Patient_Information.BL.Models;
using Patient_Information.DAL.Repository;


namespace Patient_Information.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInformations : ControllerBase
    {
        private readonly IPatientRepository repository;

        public PatientInformations(IPatientRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("GetDiseases")]
        public async Task<IActionResult> GetDiseases()
        {
            var diseases = await repository.GetDiseases();
            return Ok(diseases);
        }

        [HttpGet]
        [Route("GetPatient")]
        public async Task<IActionResult> GetPatient()
        {
            return Ok(await repository.GetPatient());
        }

        [HttpGet]
        [Route("GetNCD")]
        public async Task<ActionResult<IEnumerable<NCD>>> GetNCD()
        {
            return Ok(await repository.GetNCD());
        }


        [HttpGet]
        [Route("GetAllergies")]
        public async Task<ActionResult<IEnumerable<Allergies>>> GetAllergies()
        {
            return Ok(await repository.GetAllergies());
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPatientInformation()
        {
            return Ok( await repository.GetAllPatientInformation());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientInformationById(int id)
        {
            return Ok(await repository.GetPatientInformationById(id));
        }


        [HttpPost]
        public async Task<ActionResult> PostPatientInformation(PatientDTO patientDTO)
        {
            await repository.PostPatientInformation(patientDTO);
            return Ok();
        }


        // POST: api/PatientInformations/Update
        [Route("Update")]
        [HttpPost]
        public async Task<ActionResult> UpdatePatientInformation(PatientDTO patientDTO)
        {
            await repository.UpdatePatientInformation(patientDTO);
            return Ok();
        }

        // POST: api/PatientInformations/Delete
        [Route("Delete/{id}")]
        [HttpPost]
        public async Task<ActionResult> DeleteBookingEntry(int id)
        {
            await repository.DeletePatientInformation(id);
            return Ok();
        }
    }  
}