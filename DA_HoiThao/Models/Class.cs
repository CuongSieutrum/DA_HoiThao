using System.ComponentModel.DataAnnotations;

namespace DA_HoiThao.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Range(0, 1000000000)]
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
