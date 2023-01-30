namespace Agrades.Data.Entities;
[Table(nameof(Address))]
public class Address : ITrackable, IVersionable
{
    public Guid Id { get; set; }

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = null!;
    /// <summary>
    /// Ulice
    /// </summary>
    public string? Street { get; set; }
    /// <summary>
    /// Číslo popisné
    /// </summary>
    public string? DescNumber { get; set; }
    /// <summary>
    /// Číslo orientační
    /// </summary>
    public string? OriNumber { get; set; }
    /// <summary>
    /// Město
    /// </summary>
    public string? City { get; set; }
    /// <summary>
    /// Městská část
    /// </summary>
    public string? CityDistrict { get; set; }
    /// <summary>
    /// Okres
    /// </summary>
    public string? StateDistrict { get; set; }
    /// <summary>
    /// Kraj
    /// </summary>
    public string? Region { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public Instant ValidSince { get; set; }
    public Instant? ValidUntil { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
