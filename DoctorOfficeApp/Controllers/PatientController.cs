using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;

namespace DoctorOffice.Controllers
{
    public class PatientController : Controller
    {
        private readonly DoctorOfficeContext _db;
        public PatientController(DoctorOfficeContext db)
        {
            _db = db;
        }
        [HttpGet("/patient/add")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost("/patient/add")]
        public ActionResult AddPatient(Patient pat)
        {
            _db.Patients.Add(pat);
            _db.SaveChanges();
            return Redirect("/");
        }

        [HttpPost("/patient/{id}/add")]
        public ActionResult AddPatientDoctor(int id, string drop_name)
        {
            int dropInt = int.Parse(drop_name);
            Patient thisPatient = _db.Patients.FirstOrDefault(pat => pat.patient_id == dropInt);
            DocPat newDocPat = new DocPat();
            newDocPat.doctor_id = id;
            newDocPat.patient_id = dropInt;
            _db.DocPat.Add(newDocPat);
            _db.SaveChanges();
            return Redirect($"/doctor/{id}");
        }

        [HttpPost("/patient/delete/{id}/{doc}")]
        public ActionResult Delete(int id, int doc)
        {
            List<DocPat> thisLinks = _db.DocPat.Where(dp => dp.patient_id == id && dp.doctor_id == doc).ToList();
            foreach (DocPat dp in thisLinks) {
                _db.DocPat.Remove(dp);
            }
            _db.SaveChanges();
            return Redirect($"/doctor/{doc}");
        }
    }
}