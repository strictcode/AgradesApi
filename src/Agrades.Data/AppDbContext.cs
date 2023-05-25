using Agrades.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Hosting;

namespace Agrades.Data;
public class AppDbContext : IdentityUserContext<User, Guid>
{
    private readonly IHostEnvironment _hostEnvironment;

    public DbSet<Address> Addresses { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Class> Classes { get; set; } = null!;

    public DbSet<ClassDetail> ClassDetails { get; set; } = null!;

    public DbSet<Group> Groups { get; set; } = null!;

    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<StudentDetail> StudentDetails { get; set; } = null!;
    public DbSet<StudentGroup> StudentGroups { get; set; } = null!;

    public DbSet<Operation> Operations { get; set; } = null!;

    public DbSet<Organization> Organizations { get; set; } = null!;

    public DbSet<Person> Persons { get; set; } = null!;

    public DbSet<PersonDetail> PersonDetails { get; set; } = null!;

    public DbSet<StudyField> StudyFields { get; set; } = null!;

    public DbSet<VirtualOperation> VirtualOperations { get; set; } = null!;

    public DbSet<Raor> Raor{ get; set; } = null!;
    public DbSet<Rast> Rast { get; set; } = null!;
    public DbSet<Rauj> Rauj { get; set; } = null!;

    public DbSet<Raso> Raso { get; set; } = null!;

    public AppDbContext(
        DbContextOptions options,
        IHostEnvironment hostEnvironment
        )
        : base(options)
    {
        _hostEnvironment = hostEnvironment;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_hostEnvironment.IsDevelopment())
        {
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly)
            .ApplyNoncascadingForeignKey()
        ;
        modelBuilder.Entity<Operation>()
          .HasIndex(x => x.UrlName)
          .IsUnique();
    }
}

public static class ModelBuilderExtensions
{
    public static ModelBuilder ApplyNoncascadingForeignKey(this ModelBuilder builder)
    {
        foreach (IMutableForeignKey item in builder.Model.GetEntityTypes().SelectMany((IMutableEntityType x) => x.GetReferencingForeignKeys()))
        {
            item.DeleteBehavior = DeleteBehavior.Restrict;
        }

        return builder;
    }
}
