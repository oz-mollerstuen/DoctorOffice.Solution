using System.ComponentModel.DataAnnotations;

namespace DoctorOffice.Models {
    public class Patient {
        [Key]
        public int patient_id {get; set;}
        public string name {get; set;}
        public string birthday {get; set;}
    }
}