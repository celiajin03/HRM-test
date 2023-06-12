using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class JobRequestModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter Title of the Job")]
    [StringLength(80)]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Please enter Job Description")]
    [StringLength(2048)]
    public string Description { get; set; }

    [Required(ErrorMessage = "Please enter Job Start Date")]
    // start date cannot be in the past 
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }
    
    [Required(ErrorMessage = "please enter number")]
    public int NumberOfPositions { get; set; }
    
}