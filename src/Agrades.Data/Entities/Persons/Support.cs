namespace Agrades.Data.Entities.Persons;
public class Support : ITrackable, IVersionable
{
    public Guid Id { get; set; }

    public Guid OperationId { get; set; }
    // don't create it to database just yet
    //public Operation Operation { get; set; }
    public Guid StudentId { get; set; }
    // don't create it to database just yet
    //public Student Student { get; set; }

    public string ClassCode { get; set; } = null!;

    public int? CounsellingRedIzo { get; set; }

    public int? Financing { get; set; }

    public string? FinancingCode { get; set; }

    public LocalDate DecisionValidSince { get; set; }
    public LocalDate DecisionValidTo { get; set; }

    public LocalDate StartDate { get; set; }
    public LocalDate? EndDate { get; set; }

    public LocalDate? RealStartDate { get; set; }
    public LocalDate? RealEndDate { get; set; }

    public Instant ValidSince { get; set; }
    public Instant? ValidUntil { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
