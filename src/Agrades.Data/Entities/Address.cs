namespace Agrades.Data.Entities;
[Table(nameof(Address))]
public class Address : ITrackable
{
    public Guid Id { get; set; }

    public Guid OperationId { get; set; }
    public Operation Operation { get; set; } = null!;

    public string? Street { get; set; }

    public string? DescNumber { get; set; }

    public string? OriNumber { get; set; }

    public string? City { get; set; }

    public string? CityDistrict { get; set; }

    public string? StateDistrict { get; set; }

    public string? Region { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
