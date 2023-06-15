using Agrades.Data.Entities.Categories;

namespace Agrades.Data.Entities.Persons;
public class Recommendation : ITrackable, IVersionable
{
    //A
    public Guid Id { get; set; }
    public Guid OperationId { get; set; }
    // don't create it to database just yet
    public Operation Operation { get; set; }

    // z předchozího systémů může být kód, který škola nepoužívá
    // viz naše matrika, kód je ze škola-online, ale my máme jiné
    public string? StudentCode { get; set; }

    public Guid StudentId { get; set; }
    // don't create it to database just yet
    public Student Student { get; set; }


    // enum!!! INDI
    //0/1/5/9
    public Indi? Individual { get; set; }

    //NADANI 0- bez, 1- s
    public Gifted? Gifted { get; set; }

    //SZ 0,K,Z,V
    //create enum 
    public Sz? Sz { get; set; }

    //ZZ 0/1
    public string? Zz { get; set; }

    //PSPO
    //1-5 level, just asumed
    public AdjustedAidLevel? ProvidedLevelOfAid { get; set; }
    //PRODL_DV
    public string? AdjustedLevelOfStudyLength { get; set; }
    //UPR_VYST 0 bez, 1 s
    public AdjusteOutputLevel? AdjustedLevelOfExpectedOutput { get; set; }
    public Instant ValidSince { get; set; }
    public Instant? ValidUntil { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
