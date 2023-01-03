using System.ComponentModel.DataAnnotations;

namespace DoctorOffice.Models {
    public class DocPat {
        [Key]
        public int docpat_id {get; set;}
        public int patient_id {get; set;}
        public int doctor_id {get; set;}
        public Doctor doctor {get; set;}
        public Patient patient {get; set;}
    }
}