using System.Runtime;

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

    //KOD_ZMEN
    public Rakz? ChangeReasonCode { get; set; }
    
    //ZMENDAT
    public LocalDate StartAt { get; set; }

    //RED_IZO
    public string? CounsellingRedIzo { get; set; }

    //IZO_SPZ
    public string? CouncelingCenterIZO { get; set; }

    //ID_ZNEV
    public Guid DisabilityCodeId { get; set; }
    public IdOfDisadvantage? DisabilityCode { get; set; }

    //PSPO
    public string? LevelOfMeasuresProvided { get; set; }

    //FN  0/1
    public int? Financing { get; set; }

    //KOD_NFN
    //translator will be needed
    public string? FinancingCode { get; set; }

    //DAT_VYD
    public LocalDate DecisionValidSince { get; set; }

    //DAT_KPD
    public LocalDate? DecisionValidTo { get; set; }

    //PLAT_ZAC
    public LocalDate StartDate { get; set; }
    //PLAT_KON
    public LocalDate? EndDate { get; set; }
    
    //DAT_ZAH
    public LocalDate? RealStartDate { get; set; }
    //DAT_UKON
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
