using System.ComponentModel.DataAnnotations;

namespace DoctorOffice.Models {
    public class Specialty {
        [Key]
        public int specialty_id {get; set;}
        public string name {get; set;}
    }
}