using Agrades.Api.Mapper;
using Agrades.Data.Entities;
using Newtonsoft.Json;

namespace Agrades.Api.ApiModels.Adresses;
public class AddressPerson
{
    [JsonProperty("street")]
    public string? Street { get; set; }

    [JsonProperty("descNumber")]
    public string? DescNumber { get; set; }

    [JsonProperty("oriNumber")]
    public string? OriNumber { get; set; }

    [JsonProperty("city")]
    public string? City { get; set; }

    [JsonProperty("cityDistrict")]
    public string? CityDistrict { get; set; }

    [JsonProperty("stateDistrict")]
    public string? StateDistrict { get; set; }

    [JsonProperty("region")]
    public string? Region { get; set; }

    [JsonProperty("state")]
    public string? State { get; set; }

    [JsonProperty("zipCode")]
    public string? ZipCode { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("phoneNumber")]
    public string? PhoneNumber { get; set; }
}

public static class PersonDetailModelExtenstions
{
    public static AddressPerson ToDetail(this IAppMapper mapper, Address source)
        => new()
        {
            City = source.City,
            CityDistrict = source.CityDistrict,
            DescNumber = source.DescNumber,
            Email = source.Email,
            OriNumber = source.OriNumber,
            PhoneNumber = source.PhoneNumber,
            Region = source.Region,
            State = source.State.Name,
            StateDistrict = source.StateDistrict,
            Street = source.Street,
            ZipCode = source.ZipCode,
        };
}
