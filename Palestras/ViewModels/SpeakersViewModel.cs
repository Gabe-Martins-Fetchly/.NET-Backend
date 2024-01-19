using System;
using System.ComponentModel.DataAnnotations;

namespace Lecture.ViewModels
{
    public class SpeakersViewModel : EditImagemViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Qualification")]
        public string Qualification { get; set; }

        [Required]
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
        public string Local { get; set; }
    }
}
