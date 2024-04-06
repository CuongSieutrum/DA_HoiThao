using System.ComponentModel.DataAnnotations;

namespace DA_HoiThao.Models
{
    public class Student
    {
        public int Id{ get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        

        public string Sex { get; set; }
        public string Email { get; set; }
        public string  PhoneNumber { get; set; }
        public int Age { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
