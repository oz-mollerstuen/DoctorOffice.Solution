using Microsoft.EntityFrameworkCore;

namespace DoctorOffice.Models
{
    public class DoctorOfficeContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<DocPat> DocPat { get; set; }
        public DbSet<DocSpec> DocSpec { get; set; }
        public DoctorOfficeContext(DbContextOptions options) : base(options) { }


    }
}