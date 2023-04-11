﻿// <auto-generated />
using System;
using Agrades.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Agrades.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Agrades.Data.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CityDistrict")
                        .HasColumnType("text");

                    b.Property<Instant>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<string>("DescNumber")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<Instant>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<string>("OriNumber")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("StateDistrict")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<Instant>("ValidSince")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Instant?>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CategoryType")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryTypeId")
                        .HasColumnType("integer");

                    b.Property<Instant>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<Instant>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid>("UniqueStamp")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("RowCount")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("Agrades.Data.Entities.ClassDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<Instant>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<Instant>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<LocalDate>("StartAt")
                        .HasColumnType("date");

                    b.Property<Instant>("ValidSince")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Instant?>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("OperationId");

                    b.ToTable("ClassDetail");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BackofficeName")
                        .HasColumnType("text");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<Instant>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("EducationFieldId")
                        .HasColumnType("uuid");

                    b.Property<Instant>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<Instant>("ValidSince")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Instant?>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("EducationFieldId");

                    b.HasIndex("OperationId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Operation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Instant>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<string>("IdentificationCode")
                        .HasColumnType("text");

                    b.Property<int>("IdentificationCodeTypeId")
                        .HasColumnType("integer");

                    b.Property<Instant>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<string>("PartNumberForRegister")
                        .HasColumnType("text");

                    b.Property<int>("SchoolType")
                        .HasColumnType("integer");

                    b.Property<string>("UrlName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UrlNameNormalized")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UrlName")
                        .IsUnique();

                    b.ToTable("Operation");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Instant>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<string>("IdentificationCode")
                        .HasColumnType("text");

                    b.Property<int>("IdentificationCodeTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsSingleOperationOrg")
                        .HasColumnType("boolean");

                    b.Property<Instant>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RedIzo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Persons.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<int>("PersonTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(101);

                    b.Property<int>("RowCount")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Persons.PersonDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BackofficeNote")
                        .HasColumnType("text");

                    b.Property<Guid?>("BirthAddressId")
                        .HasColumnType("uuid");

                    b.Property<string>("BirthName")
                        .HasColumnType("text");

                    b.Property<LocalDate?>("BornOn")
                        .HasColumnType("date");

                    b.Property<int?>("Citizenship")
                        .HasColumnType("integer");

                    b.Property<int?>("CitizenshipCode")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ContactAddressId")
                        .HasColumnType("uuid");

                    b.Property<Instant>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DataBox")
                        .HasColumnType("text");

                    b.Property<string>("DegreesPost")
                        .HasColumnType("text");

                    b.Property<string>("DegreesPre")
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<int?>("FamilyStatusId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentificationCode")
                        .HasColumnType("text");

                    b.Property<int?>("IdentificationCodeTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("IdentityCardNumber")
                        .HasColumnType("text");

                    b.Property<int?>("IdentityCardNumberTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("InactivityReasonId")
                        .HasColumnType("integer");

                    b.Property<string>("InsuranceCompanyCode")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<string>("OrganizationUniqueCode")
                        .HasColumnType("text");

                    b.Property<Guid?>("PermanentAddressId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Sex")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("TemporaryAddressId")
                        .HasColumnType("uuid");

                    b.Property<Instant>("ValidSince")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Instant?>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BirthAddressId");

                    b.HasIndex("ContactAddressId");

                    b.HasIndex("OperationId");

                    b.HasIndex("PermanentAddressId");

                    b.HasIndex("PersonId");

                    b.HasIndex("TemporaryAddressId");

                    b.ToTable("PersonDetail");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Persons.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<int>("RowCount")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Persons.StudentDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<Instant>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<string>("EndReasonCode")
                        .HasColumnType("text");

                    b.Property<LocalDate?>("EndsAt")
                        .HasColumnType("date");

                    b.Property<int?>("Financing")
                        .HasColumnType("integer");

                    b.Property<bool?>("HasSchoolMeals")
                        .HasColumnType("boolean");

                    b.Property<int>("HighestAchievedEducation")
                        .HasColumnType("integer");

                    b.Property<bool?>("IsOnInternat")
                        .HasColumnType("boolean");

                    b.Property<Instant>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ObligatoryAttendenceYears")
                        .HasColumnType("integer");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<string>("PreviousEducationCode")
                        .HasColumnType("text");

                    b.Property<Guid?>("PreviousEducationOperationId")
                        .HasColumnType("uuid");

                    b.Property<int>("StartReasonCode")
                        .HasColumnType("integer");

                    b.Property<LocalDate>("StartsAt")
                        .HasColumnType("date");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudyFieldId")
                        .HasColumnType("uuid");

                    b.Property<Instant>("ValidSince")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Instant?>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("OperationId");

                    b.HasIndex("PreviousEducationOperationId");

                    b.HasIndex("StudentId");

                    b.HasIndex("StudyFieldId");

                    b.ToTable("StudentDetail");
                });

            modelBuilder.Entity("Agrades.Data.Entities.StudentGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Instant>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Instant>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Instant>("ValidSince")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Instant?>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentGroup");
                });

            modelBuilder.Entity("Agrades.Data.Entities.StudyField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BackofficeName")
                        .HasColumnType("text");

                    b.Property<Instant>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<int>("Form")
                        .HasColumnType("integer");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<int>("LengthInYears")
                        .HasColumnType("integer");

                    b.Property<Instant>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Qualifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("StudyField");
                });

            modelBuilder.Entity("Agrades.Data.Entities.VirtualOperation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Instant>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<string>("IdentificationCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdentificationCodeTypeId")
                        .HasColumnType("integer");

                    b.Property<Instant>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("OperationId")
                        .HasColumnType("uuid");

                    b.Property<int>("SchoolType")
                        .HasColumnType("integer");

                    b.Property<Instant>("ValidSince")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Instant?>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("VirtualOperation");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Address", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Category", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("Agrades.Data.Entities.ClassDetail", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Class", "Class")
                        .WithMany("ClassDetails")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Agrades.Data.Entities.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Group", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Class", "Class")
                        .WithMany("Groups")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Agrades.Data.Entities.StudyField", "EducationField")
                        .WithMany()
                        .HasForeignKey("EducationFieldId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Agrades.Data.Entities.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("EducationField");

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Operation", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Persons.Person", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Persons.PersonDetail", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Address", "BirthAddress")
                        .WithMany()
                        .HasForeignKey("BirthAddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Agrades.Data.Entities.Address", "ContactAddress")
                        .WithMany()
                        .HasForeignKey("ContactAddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Agrades.Data.Entities.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Agrades.Data.Entities.Address", "PermanentAddress")
                        .WithMany()
                        .HasForeignKey("PermanentAddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Agrades.Data.Entities.Persons.Person", "Person")
                        .WithMany("PersonDetails")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Agrades.Data.Entities.Address", "TemporaryAddress")
                        .WithMany()
                        .HasForeignKey("TemporaryAddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BirthAddress");

                    b.Navigation("ContactAddress");

                    b.Navigation("Operation");

                    b.Navigation("PermanentAddress");

                    b.Navigation("Person");

                    b.Navigation("TemporaryAddress");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Persons.Student", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Agrades.Data.Entities.Persons.Person", "Person")
                        .WithOne("Student")
                        .HasForeignKey("Agrades.Data.Entities.Persons.Student", "PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Operation");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Persons.StudentDetail", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Agrades.Data.Entities.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Agrades.Data.Entities.VirtualOperation", "PreviousEducationOperation")
                        .WithMany()
                        .HasForeignKey("PreviousEducationOperationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Agrades.Data.Entities.Persons.Student", "Student")
                        .WithMany("StudentDetails")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Agrades.Data.Entities.StudyField", "StudyField")
                        .WithMany()
                        .HasForeignKey("StudyFieldId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Operation");

                    b.Navigation("PreviousEducationOperation");

                    b.Navigation("Student");

                    b.Navigation("StudyField");
                });

            modelBuilder.Entity("Agrades.Data.Entities.StudentGroup", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Agrades.Data.Entities.Persons.Student", "Student")
                        .WithMany("Groups")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Agrades.Data.Entities.StudyField", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("Agrades.Data.Entities.VirtualOperation", b =>
                {
                    b.HasOne("Agrades.Data.Entities.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Class", b =>
                {
                    b.Navigation("ClassDetails");

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Persons.Person", b =>
                {
                    b.Navigation("PersonDetails");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Agrades.Data.Entities.Persons.Student", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("StudentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
