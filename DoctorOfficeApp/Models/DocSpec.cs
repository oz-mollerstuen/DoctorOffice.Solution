using System.ComponentModel.DataAnnotations;

namespace DoctorOffice.Models {
    public class DocSpec {
        [Key]
        public int docspec_id {get; set;}
        public int specialty_id {get; set;}
        public int doctor_id {get; set;}
        public Doctor doctor {get; set;}
        public Specialty specialty {get; set;}
    }
}