using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;

namespace DoctorOffice.Controllers
{
    public class SpecialtyController : Controller
    {
        private readonly DoctorOfficeContext _db;
        public SpecialtyController(DoctorOfficeContext db)
        {
            _db = db;
        }

        [HttpGet("/specialty/add")]
        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost("/specialty/add")]
        public ActionResult AddSpecialty(Specialty spec)
        {
            _db.Specialties.Add(spec);
            _db.SaveChanges();
            return Redirect("/");
        }
        
        [HttpPost("/specialty/{id}/add")]
        public ActionResult AddSpecialtyDoctor(int id, string drop_name)
        {
            int dropInt = int.Parse(drop_name);
            Specialty thisSpecialty = _db.Specialties.FirstOrDefault(spec => spec.specialty_id == dropInt);
            DocSpec newDocSpec = new DocSpec();
            newDocSpec.doctor_id = id;
            newDocSpec.specialty_id = dropInt;
            _db.DocSpec.Add(newDocSpec);
            _db.SaveChanges();
            return Redirect($"/doctor/{id}");
        }

        [HttpPost("/specialty/delete/{id}/{doc}")]
        public ActionResult Delete(int id, int doc)
        {
            List<DocSpec> thisLinks = _db.DocSpec.Where(ds => ds.specialty_id == id && ds.doctor_id == doc).ToList();
            foreach (DocSpec ds in thisLinks) {
                _db.DocSpec.Remove(ds);
            }
            _db.SaveChanges();
            return Redirect($"/doctor/{doc}");
        }
    }
    }
