using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;

namespace DoctorOffice.Controllers
{
  public class DoctorController : Controller
  {
    private readonly DoctorOfficeContext _db;
    public DoctorController(DoctorOfficeContext db)
    {
      _db = db;
    }
    
    [HttpGet("/doctor/{id}")]
    public ActionResult Index(int id) {
      Doctor thisDoctor = _db.Doctors.FirstOrDefault(doc => doc.doctor_id == id);
      List<DocPat> thisPatLinks = _db.DocPat.Where(doc => doc.doctor_id == id).ToList();
      List<Patient> thisPatients = new List<Patient>{};
      foreach (DocPat dp in thisPatLinks)
      {
        Patient getPatient = _db.Patients.FirstOrDefault(pat => pat.patient_id == dp.patient_id);
        thisPatients.Add(getPatient);
      }
      ViewBag.Patients = _db.Patients.ToList();
      ViewBag.DocPatients = thisPatients;

      List<DocSpec> thisSpecLinks = _db.DocSpec.Where(doc => doc.doctor_id == id).ToList();
      List<Specialty> thisSpecialty = new List<Specialty>{};
      foreach (DocSpec dp in thisSpecLinks)
      {
        Specialty getSpecialty = _db.Specialties.FirstOrDefault(spec => spec.specialty_id == dp.specialty_id);
        thisSpecialty.Add(getSpecialty);
      }
      ViewBag.DocSpecialty = thisSpecialty;
      ViewBag.Specialty = _db.Specialties.ToList();
      return View(thisDoctor);
    }

    [HttpPost("/doctor/add")]
    public ActionResult AddDoctor(Doctor doc) {
      _db.Doctors.Add(doc);
      _db.SaveChanges();
      return Redirect("/");
    }

    [HttpPost("/doctor/delete/{id}")]
    public ActionResult Delete(int id)
    {
        Doctor thisDoctor = _db.Doctors.FirstOrDefault(doc => doc.doctor_id == id);
        List<DocSpec> thisSpecLinks = _db.DocSpec.Where(ds => ds.doctor_id == id).ToList();
        foreach (DocSpec ds in thisSpecLinks) {
            _db.DocSpec.Remove(ds);
        }
        List<DocPat> thisPatLinks = _db.DocPat.Where(dp => dp.doctor_id == id).ToList();
        foreach (DocPat dp in thisPatLinks) {
            _db.DocPat.Remove(dp);
        }
        _db.Doctors.Remove(thisDoctor);
        _db.SaveChanges();
        return Redirect("/");
    }
  }
}