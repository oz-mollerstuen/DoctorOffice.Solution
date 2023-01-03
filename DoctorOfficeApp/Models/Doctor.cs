using System.ComponentModel.DataAnnotations;

namespace DoctorOffice.Models {
    public class Doctor {
        [Key]
        public int doctor_id {get; set;}
        public string name {get; set;}
    }
}