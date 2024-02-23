using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using Patient_Information.Data;
using Patient_Information.Models;
using Patient_Information.ViewModels;

namespace Patient_Information.Controllers
{
    public class PatientsController : Controller
    {
        private readonly PatientDbContext _context;

        public PatientsController(PatientDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var patientDbContext = _context.Patients
                .Include(p => p.Diseases)
                .Include(p=>p.NCD_Details).ThenInclude(n=>n.NCD)
                .Include(p=>p.AllergiesDetails).ThenInclude(a=>a.Allergies);
            return View(await patientDbContext.ToListAsync());
        }


        public IActionResult AddNewNCD(int? id)
        {
            ViewBag.NCD = new SelectList(_context.NCDs, "NCDId", "NCDName", id.ToString() ?? "");
            return PartialView("_addNewNCD");
        }
        
        
        public IActionResult AddNewAllergies(int? id)
        {
            ViewBag.Allergies = new SelectList(_context.Allergies, "AllergiesId", "AllergiesName", id.ToString() ?? "");
            return PartialView("_addNewAllergies");
        }




        public IActionResult Create()
        {
            ViewBag.Diseases = new SelectList(_context.Diseases, "DiseasesId", "DiseasesName");
            ViewBag.Epilepsy = new SelectList(Enum.GetValues(typeof(Epilepsy)));
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientVM patientVM, int[] NCDId, int[] AllergiesId)
        {
            if (ModelState.IsValid)
            {
                Patient patient = new Patient()
                {
                    PatientName = patientVM.PatientName,
                    DiseasesId=patientVM.DiseasesId,
                    Epilepsy = patientVM.Epilepsy
                };
                           
                foreach (var item in NCDId)
                {
                    NCD_Details nCD_Details = new NCD_Details()
                    {
                        Patient=patient,
                        PatientId=patient.PatientId,
                        NCDId=item
                    };
                    _context.NCD_Details.Add(nCD_Details);
                }

                foreach (var item in AllergiesId)
                {
                    AllergiesDetails allergiesDetails = new AllergiesDetails()
                    {
                        Patient = patient,
                        PatientId = patient.PatientId,
                        AllergiesId = item
                    };
                    _context.AllergiesDetails.Add(allergiesDetails);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public async Task<IActionResult> Edit(int? id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == id);
            PatientVM patientVM = new PatientVM()
            {
                PatientId = patient.PatientId,
                PatientName=patient.PatientName,
                DiseasesId=patient.DiseasesId,
                Epilepsy=patient.Epilepsy
            };

            var existNCD = _context.NCD_Details.Where(x => x.PatientId == id).ToList();
            foreach (var item in existNCD)
            {
                patientVM.NCDList.Add(item.NCDId);
            }

            var existAllergies = _context.AllergiesDetails.Where(x=>x.PatientId == id).ToList();
            foreach(var item in existAllergies)
            {
                patientVM.AllergiesList.Add(item.AllergiesId);
            }

            ViewBag.Diseases = new SelectList(_context.Diseases, "DiseasesId", "DiseasesName");
            ViewBag.Epilepsy = new SelectList(Enum.GetValues(typeof(Epilepsy)));
            return View(patientVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientVM patientVM, int[] NCDId, int[] AllergiesId)
        {
            if (ModelState.IsValid)
            {
                Patient patient = new Patient()
                {
                    PatientId= patientVM.PatientId,
                    PatientName = patientVM.PatientName,
                    DiseasesId=patientVM.DiseasesId,
                    Epilepsy=patientVM.Epilepsy
                };

                var existNCD = _context.NCD_Details.Where(x => x.PatientId == patient.PatientId).ToList();
                foreach (var item in existNCD)
                {
                    _context.NCD_Details.Remove(item);
                }
                foreach (var item in NCDId)
                {
                    NCD_Details nCD_Details = new NCD_Details()
                    {
                        PatientId = patient.PatientId,
                        NCDId = item
                    };
                    _context.NCD_Details.Add(nCD_Details);
                }

                var existAllergies = _context.AllergiesDetails.Where(x => x.PatientId == patient.PatientId).ToList();
                foreach (var item in existAllergies)
                {
                    _context.AllergiesDetails.Remove(item);
                }
                foreach (var item in AllergiesId)
                {
                    AllergiesDetails allergiesDetails = new AllergiesDetails()
                    {
                        PatientId = patient.PatientId,
                        AllergiesId = item
                    };
                    _context.AllergiesDetails.Add(allergiesDetails);
                }

                _context.Update(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .Include(p => p.Diseases)
                .Include(p=>p.NCD_Details).ThenInclude(n=>n.NCD)
                .Include(p=>p.AllergiesDetails).ThenInclude(a=>a.Allergies)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
