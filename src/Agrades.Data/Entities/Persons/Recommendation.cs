namespace Agrades.Data.Entities.Persons;
public class Recommendation : ITrackable, IVersionable
{
    public Guid Id { get; set; }
    public Guid OperationId { get; set; }
    // don't create it to database just yet
    //public Operation Operation { get; set; }

    // z předchozího systémů může být kód, který škola nepoužívá
    // viz naše matrika, kód je ze škola-online, ale my máme jiné
    public string? StudentCode { get; set; }
    // enum probably
    public string GroupType { get; set; } = null!;

    // enum!!!
    public string Individual { get; set; } = null!;

    public bool Gifted { get; set; }

    public string Sz { get; set; }
    public Guid StudentId { get; set; }
    // don't create it to database just yet
    //public Student Student { get; set; }
    public Instant ValidSince { get; set; }
    public Instant? ValidUntil { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
