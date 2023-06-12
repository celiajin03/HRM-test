using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class SubmissionRequestModel
{
    [Required(ErrorMessage = "Please enter your First Name")]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter your Last Name")]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter your Email")]
    [StringLength(512)]
    public string Email { get; set; }

    [StringLength(2048)]
    public string ResumeURL { get; set; }

    [DataType(DataType.Date)]
    public DateTime? SubmittedOn { get; set; }
}