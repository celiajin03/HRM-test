using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Interview
{
    public int Id { get; set; }
    public DateTime BeginTime { get; set; }
    public string CandidateEmail { get; set; }
    
    [MaxLength(50)]
    public string CandidateFirstName { get; set; }
    public Guid CandidateIdentityId { get; set; }
    
    [MaxLength(50)]
    public string CandidateLastName { get; set; }
    public DateTime EndTime { get; set; }
    public string? Feedback { get; set; }
    
    [ForeignKey("Interviewer")]
    public int InterviewerId { get; set; }
    public Interviewer Interviewer { get; set; }
    
    [ForeignKey("InterviewTypeLookUp")]
    public int InterviewTypeId { get; set; }
    public InterviewTypeLookUp InterviewTypeLookUp { get; set; }
    
    public bool? Passed { get; set; }
    public int? Rating { get; set; }
    public int SubmissionId { get; set; }

    // // Navigation property
    // public InterviewTypeLookUp InterviewTypeLookUp { get; set; }
    // public Interviewer Interviewer { get; set; }
}
