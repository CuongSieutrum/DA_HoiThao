using System.ComponentModel.DataAnnotations;

namespace DA_HoiThao.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}