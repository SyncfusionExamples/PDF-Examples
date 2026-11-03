using System.ComponentModel.DataAnnotations;

namespace Certificate_to_PDF.Models
{
    public class CertificateModel
    {
        [Required]
        [Display(Name = "Participant name")]
        public string ParticipantName { get; set; }

        [Required]
        [Display(Name = "Competition title")]
        public string CompetitionTitle { get; set; }

        [Required]
        [Display(Name = "Date")]
        public string DateText { get; set; }

        [Display(Name = "Exam mode")]
        public string ExamMode { get; set; } = "Online";

        [Display(Name = "Description")]
        public string Description { get; set; } =
            "The competition was based on six video Lectures delivered by Shaykh-ul-Islam " +
            "Dr. Muhammad Tahir-ul-Qadri, focusing on the rational and spiritual foundations of faith and religion.";
    }
}
