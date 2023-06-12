using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class CandidateUpdateModel
{
    [MaxLength(2048)]
    public string? ResumeURL { get; set; }
}