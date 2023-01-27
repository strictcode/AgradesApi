using Agrades.Api.ApiModels.Persons;
using Agrades.Api.Mapper;
using Agrades.Api.Utilities;
using Agrades.Data;
using Agrades.Data.Entities;
using Agrades.Data.Entities.Persons;
using Agrades.Data.Interfaces;
using Agrades.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace Agrades.Api.Controllers;
[ApiController]
public class RecordController : ControllerBase
{
    private readonly ILogger<RecordController> _logger;
    private readonly AppDbContext _dbContext;
    private readonly ICurrentOperationService _currentOperationService;
    private readonly IAppMapper _mapper;
    private readonly IClock _clock;

    public RecordController(
        ILogger<RecordController> logger,
        AppDbContext dbContext,
        ICurrentOperationService currentOperationService,
        IAppMapper mapper,
        IClock clock
        )
    {
        _logger = logger;
        _dbContext = dbContext;
        _currentOperationService = currentOperationService;
        _mapper = mapper;
        _clock = clock;
    }

    /// <summary>
    /// Create Person, Student, and return PersonId, designated PersonDetailId, StudentId, designated StudentDetailId.
    /// </summary>
    /// <param name="opUrlName"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    [HttpPost("/api/v1/{opUrlName}/Record/{number}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<string>>> Get(
        [FromRoute] string opUrlName,
        [FromRoute] int number
        )
    {
        var currentOp = await _currentOperationService.GetCurrentOperationAsync(opUrlName);
        var now = _clock.GetCurrentInstant();

        var output = new Guid[number, 4];

        if (currentOp == null)
        {
            return NotFound("Operation not found.");
        }
        var tmp = Guid.Empty;
        for (int i = 0; i < number; i++)
        {
            var person = new Person();
            var personDetail = new PersonDetail { Person = person }.SetCreateBySystem(now);
            var student = new Student { Person = person };
            var studentDetail = new StudentDetail { Student = student }.SetCreateBySystem(now);

            // ID se vygeneruje při Add
            await _dbContext.AddAsync(person);
            await _dbContext.AddAsync(personDetail);
            await _dbContext.AddAsync(student);
            await _dbContext.AddAsync(studentDetail);
        }

        return Ok();
    }

    private record CreateResult
    {
        public string PersonId { get; set; } = null!;
        public string PersonDetailId { get; set; } = null!;

        public string StudentId { get; set; } = null!;
        public string StudentDetailId { get; set; } = null!;
    }

    [HttpGet("/api/v1/{opUrlName}/Record/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonDetailDetail>> Get(
        [FromRoute] string opUrlName,
        [FromRoute] Guid id
        )
    {
        var currentOp = await _currentOperationService.GetCurrentOperationAsync(opUrlName);

        if (currentOp == null)
        {
            return NotFound("Operation not found.");
        }

        var person = await _dbContext.Persons
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (person == null)
        {
            return NotFound("Person not found.");
        }

        var personDetail = await _dbContext.Set<PersonDetail>()
            .Where(x => x.PersonId == id)
            .OrderByDescending(x => x.ValidSince)
            .FirstOrDefaultAsync();

        if (personDetail == null)
        {
            return NotFound();
        }

        return Ok(_mapper.ToDetail(personDetail));
    }

    [HttpGet("/api/v1/{opUrlName}/Record")]
    public async Task<ActionResult> GetList(
        [FromRoute] string opUrlName,
        [FromQuery] int? personType
        )
    {
        var currentOp = await _currentOperationService.GetCurrentOperationAsync(opUrlName);

        if (currentOp == null)
        {
            return NotFound("Operation not found");
        }

        var persons = _dbContext.PersonDetails
            .Where(x => x.OperationId == currentOp.Id);

        if (personType is not null)
        {
            persons = persons.Where(x => (int)x.PersonTypeId == personType);
        }

        return Ok(ApiListResult.From(persons.Select(x => _mapper.ToDetail(x))));
    }
}
