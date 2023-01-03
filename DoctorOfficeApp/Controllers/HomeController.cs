using Microsoft.AspNetCore.Mvc;
using DoctorOffice.Models;

namespace DoctorOffice.Controllers
{
  public class HomeController : Controller
  {
    private readonly DoctorOfficeContext _db;
    public HomeController(DoctorOfficeContext db)
    {
      _db = db;
    }
    
    [HttpGet("/")]
    public ActionResult Index() {
      List<Doctor> doctors = _db.Doctors.ToList();
      return View(doctors);
    }
  }
}