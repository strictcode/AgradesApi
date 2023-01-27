namespace Agrades.Data.Seeds;
public static class ITGSeed
{
    public static async Task SeedAsync(
        IClock clock,
        AppDbContext dbContext
        )
    {
        var now = clock.GetCurrentInstant();

        var organization = new Organization
        {
            Id = DatabaseConstants.ITG.OrganizationId,
            Name = "1. IT Gymnázium, s.r.o.",
            RedIzo = "691 013 489",
            IsSingleOperationOrg = true,
        }.SetCreateBySystem(now);

        var operation = new Operation
        {
            Id = DatabaseConstants.ITG.OperationId,
            OrganizationId = organization.Id,
            UrlName = "ITG",
            UrlNameNormalized = "ITG".ToLower(),
            IdentificationCode = "181 105 527",
            Organization = organization,
        }.SetCreateBySystem(now);

        var fieldOfStudy = new StudyField
        {
            Id = DatabaseConstants.ITG.FieldOfStudyId,
            Name = "Gymnázium",
            Qualifier = "79-41-K/81",
            Type = FieldOfStudyType.HighSchoolWithLeavingExam,
            BackofficeName = "Gymnázium od 2020",
            OperationId = operation.Id,
        }.SetCreateBySystem(now);

        var icko = new Class
        {
            Id = DatabaseConstants.ITG.Icko,
            Name = "I",
            StartAt = Instant.FromUtc(2020, 9, 1, 0, 0),
            OperationId = operation.Id, 
        }.SetCreateBySystem(now);

        var g1 = new Group {
            Id = DatabaseConstants.ITG.IckoGroup,
            Class = icko,
            Name = "Hlavní skupina",
            EducationField = fieldOfStudy,
            OperationId = operation.Id,
        }.SetCreateBySystem(now);

        var tecko = new Class
        {
            Id = DatabaseConstants.ITG.Tecko,
            Name = "T",
            StartAt = Instant.FromUtc(2020, 9, 1, 0, 0),
            OperationId = operation.Id,
        }.SetCreateBySystem(now);

        var g2 = new Group
        {
            Id = DatabaseConstants.ITG.TeckoGroup,
            Class = tecko,
            Name = "Hlavní skupina",
            EducationField = fieldOfStudy,
            OperationId = operation.Id,
        }.SetCreateBySystem(now);

        var alfa = new Class
        {
            Id = DatabaseConstants.ITG.Alfa,
            Name = "α",
            StartAt = Instant.FromUtc(2021, 9, 1, 0, 0),
            OperationId = operation.Id,
        }.SetCreateBySystem(now);

        var g3 = new Group
        {
            Id = DatabaseConstants.ITG.AlfaGroup,
            Class = alfa,
            Name = "Hlavní skupina",
            EducationField = fieldOfStudy,
            OperationId = operation.Id,
        }.SetCreateBySystem(now);

        var omega = new Class
        {
            Id = DatabaseConstants.ITG.Omega,
            Name = "ω",
            StartAt = Instant.FromUtc(2021, 9, 1, 0, 0),
            OperationId = operation.Id,
        }.SetCreateBySystem(now);

        var g4 = new Group
        {
            Id = DatabaseConstants.ITG.OmegaGroup,
            Class = omega,
            Name = "Hlavní skupina",
            EducationField = fieldOfStudy,
            OperationId = operation.Id,
        }.SetCreateBySystem(now);

        var alt = new Class
        {
            Id = DatabaseConstants.ITG.Alt,
            Name = "Alt",
            StartAt = Instant.FromUtc(2022, 9, 1, 0, 0),
            OperationId = operation.Id,
        }.SetCreateBySystem(now);

        var g5 = new Group
        {
            Id = DatabaseConstants.ITG.AltGroup,
            Class = alt,
            Name = "Hlavní skupina",
            EducationField = fieldOfStudy,
            OperationId = operation.Id,
        }.SetCreateBySystem(now);

        var f4 = new Class
        {
            Id = DatabaseConstants.ITG.F4,
            Name = "F4",
            StartAt = Instant.FromUtc(2022, 9, 1, 0, 0),
            OperationId = operation.Id,
        }.SetCreateBySystem(now);

        var g6 = new Group
        {
            Id = DatabaseConstants.ITG.F4Group,
            Class = f4,
            Name = "Hlavní skupina",
            EducationField = fieldOfStudy,
            OperationId = operation.Id,
        }.SetCreateBySystem(now);
        /*
        dbContext.Add(organization);
        dbContext.Add(operation);
        dbContext.Add(fieldOfStudy);
        dbContext.Add(icko);
        dbContext.Add(tecko);
        dbContext.Add(alfa);
        dbContext.Add(omega);
        dbContext.Add(alt);
        dbContext.Add(f4);
        dbContext.Add(g1);
        dbContext.Add(g2);
        dbContext.Add(g3);
        dbContext.Add(g4);
        dbContext.Add(g5);
        dbContext.Add(g6);
        */
        await dbContext.SaveChangesAsync();
    }
}
