using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi03Core.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ko dc bo trong ten")]
        [StringLength(40,MinimumLength =2,ErrorMessage ="2-40")]
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = "Ko dc bo trong sdt")]
        [Display(Name = "Phone number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Ko dc bo trong")]
        public string? Skill { get; set; }

        [Required(ErrorMessage = "Ko dc bo trong")]
        [Range(1,80,ErrorMessage ="Kinh nhgiem tu 1-80 nam")]
        public int Experiences { get; set; }

        public string? Image { get; set; }
    }
}
