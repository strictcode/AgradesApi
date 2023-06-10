using System.Runtime;

namespace Agrades.Data.Entities.Persons;
public class Support : ITrackable, IVersionable
{
    public Guid Id { get; set; }

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; }
    public Guid StudentId { get; set; }
    public Student Student { get; set; }

    //ZMENDAT
    public LocalDate StartAt { get; set; }

    //RED_IZO
    public string? CouncellingRedIzo { get; set; }

    //IZO_SPZ
    public string? CouncelingCenterIZO { get; set; }

    //FN  0/1
    public Fn? Financing { get; set; }

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
