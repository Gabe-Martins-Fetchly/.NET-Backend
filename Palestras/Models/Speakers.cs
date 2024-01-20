using System;
using System.ComponentModel.DataAnnotations;

namespace Lecture.Models
{
    public class Speakers
    {
        

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Qualification")]
        public string Qualification { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Experience")]
        public int Experience { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime DateLecture { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Time")]
        public DateTime TimeLecture { get; set; }

        [Required]
        [StringLength(250)]
        public string Local { get; set; }

        [Required]
        [StringLength(300)]
        public string Picture { get; set; }
    }
}
