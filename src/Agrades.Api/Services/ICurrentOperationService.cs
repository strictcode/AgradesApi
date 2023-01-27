using Agrades.Api.ApiModels.Operations;
using Agrades.Api.Mapper;
using Agrades.Data;
using Microsoft.EntityFrameworkCore;

namespace Agrades.Services;
public interface ICurrentOperationService
{
    Task<OperationDto?> GetCurrentOperationAsync(string name);
}

public class CurrentOperationService : ICurrentOperationService
{
    private readonly AppDbContext _dbContext;
    private readonly IAppMapper _mapper;

    public CurrentOperationService(
        AppDbContext dbContext,
        IAppMapper mapper
        )
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<OperationDto?> GetCurrentOperationAsync(string name)
    {
        var operation = await _dbContext.Operations.FirstOrDefaultAsync(x => x.UrlName == name.ToUpper());

        if (operation == null)
        {
            return null;
        }

        return _mapper.GetDto(operation);
    }
}
