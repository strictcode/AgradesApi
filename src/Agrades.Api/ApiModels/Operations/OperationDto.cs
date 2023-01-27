using Agrades.Api.Mapper;
using Agrades.Data.Entities;

namespace Agrades.Api.ApiModels.Operations;
public class OperationDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string UrlName { get; set; } = null!;

    public Guid OrgranizationId { get; set; }
}

public static class OrganizationDtoExtenstions
{
    public static OperationDto GetDto(this IAppMapper mapper, Operation source)
        => new()
        {
            Id = source.Id,
            Name = source.Name,
            UrlName = source.UrlName,
            OrgranizationId = source.OrganizationId,
        };
}
