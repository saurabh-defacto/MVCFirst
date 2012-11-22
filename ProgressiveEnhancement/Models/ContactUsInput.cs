using System.ComponentModel.DataAnnotations;

namespace ProgressiveEnhancement.Models
{
    public class ContactUsInput
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [UIHint("Multiline")]
        public string Message { get; set; }
    }
}