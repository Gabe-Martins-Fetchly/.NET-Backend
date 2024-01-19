using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Lecture.ViewModels
{
    public class UploadImagemViewModel
    {
        [Required]
        [Display(Name = "Foto")]
        public IFormFile SpeakersFoto { get; set; }
    }
}
