using System.ComponentModel.DataAnnotations;

namespace Agrades.Data.Entities;
[Table(nameof(Operation))]
public class Operation : ITrackable
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    [Required]
    public string UrlName { get; set; } = null!;

    /// <summary>
    /// It's in url - in this case normalized means lower case
    /// Everywhere else normalized is ToUpper().
    /// </summary>
    public string UrlNameNormalized { get; set; } = null!;

    /// <summary>
    /// Izo
    /// </summary>
    public string? IdentificationCode { get; set; }
    public UniqueCodeType IdentificationCodeTypeId { get; set; }

    /// <summary>
    /// Organization Part Number for ministry data collection
    /// </summary>
    public string? PartNumberForRegister { get; set; }

    /// <summary>
    /// Nevím, nevím, možná jiný RAPZ
    /// </summary>
    public int SchoolType { get; set; }

    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; } = null!;

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
