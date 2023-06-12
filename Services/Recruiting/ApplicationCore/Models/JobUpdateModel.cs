using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class JobUpdateModel
{
    public int Id { get; set; }
    public DateTime? CloseOn { get; set; }
    [StringLength(2048)]
    public string? ClosedReason { get; set; }
}