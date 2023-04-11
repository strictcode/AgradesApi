using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace Agrades.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RowCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RedIzo = table.Column<string>(type: "text", nullable: false),
                    IdentificationCode = table.Column<string>(type: "text", nullable: true),
                    IdentificationCodeTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsSingleOperationOrg = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UrlName = table.Column<string>(type: "text", nullable: false),
                    UrlNameNormalized = table.Column<string>(type: "text", nullable: false),
                    IdentificationCode = table.Column<string>(type: "text", nullable: true),
                    IdentificationCodeTypeId = table.Column<int>(type: "integer", nullable: false),
                    PartNumberForRegister = table.Column<string>(type: "text", nullable: true),
                    SchoolType = table.Column<int>(type: "integer", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: true),
                    DescNumber = table.Column<string>(type: "text", nullable: true),
                    OriNumber = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    CityDistrict = table.Column<string>(type: "text", nullable: true),
                    StateDistrict = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    ValidSince = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ValidUntil = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CategoryTypeId = table.Column<int>(type: "integer", nullable: false),
                    CategoryType = table.Column<int>(type: "integer", nullable: false),
                    UniqueStamp = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartAt = table.Column<LocalDate>(type: "date", nullable: false),
                    ValidSince = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ValidUntil = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassDetail_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassDetail_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowCount = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    PersonTypeId = table.Column<int>(type: "integer", nullable: false, defaultValue: 101)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyField",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Qualifier = table.Column<string>(type: "text", nullable: false),
                    BackofficeName = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    LengthInYears = table.Column<int>(type: "integer", nullable: false),
                    Form = table.Column<int>(type: "integer", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyField_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VirtualOperation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IdentificationCode = table.Column<string>(type: "text", nullable: false),
                    IdentificationCodeTypeId = table.Column<int>(type: "integer", nullable: false),
                    SchoolType = table.Column<int>(type: "integer", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: true),
                    ValidSince = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ValidUntil = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirtualOperation_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    InactivityReasonId = table.Column<int>(type: "integer", nullable: true),
                    OrganizationUniqueCode = table.Column<string>(type: "text", nullable: true),
                    Sex = table.Column<int>(type: "integer", nullable: true),
                    DegreesPre = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DegreesPost = table.Column<string>(type: "text", nullable: true),
                    BirthName = table.Column<string>(type: "text", nullable: true),
                    BornOn = table.Column<LocalDate>(type: "date", nullable: true),
                    FamilyStatusId = table.Column<int>(type: "integer", nullable: true),
                    IdentityCardNumberTypeId = table.Column<int>(type: "integer", nullable: true),
                    IdentityCardNumber = table.Column<string>(type: "text", nullable: true),
                    IdentificationCodeTypeId = table.Column<int>(type: "integer", nullable: true),
                    IdentificationCode = table.Column<string>(type: "text", nullable: true),
                    Citizenship = table.Column<int>(type: "integer", nullable: true),
                    CitizenshipCode = table.Column<int>(type: "integer", nullable: true),
                    InsuranceCompanyCode = table.Column<string>(type: "text", nullable: true),
                    DataBox = table.Column<string>(type: "text", nullable: true),
                    BackofficeNote = table.Column<string>(type: "text", nullable: true),
                    BirthAddressId = table.Column<Guid>(type: "uuid", nullable: true),
                    PermanentAddressId = table.Column<Guid>(type: "uuid", nullable: true),
                    TemporaryAddressId = table.Column<Guid>(type: "uuid", nullable: true),
                    ContactAddressId = table.Column<Guid>(type: "uuid", nullable: true),
                    ValidSince = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ValidUntil = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Address_BirthAddressId",
                        column: x => x.BirthAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Address_ContactAddressId",
                        column: x => x.ContactAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Address_PermanentAddressId",
                        column: x => x.PermanentAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Address_TemporaryAddressId",
                        column: x => x.TemporaryAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowCount = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    EducationFieldId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BackofficeName = table.Column<string>(type: "text", nullable: true),
                    ValidSince = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ValidUntil = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Group_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Group_StudyField_EducationFieldId",
                        column: x => x.EducationFieldId,
                        principalTable: "StudyField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: true),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartsAt = table.Column<LocalDate>(type: "date", nullable: false),
                    StartReasonCode = table.Column<int>(type: "integer", nullable: false),
                    ObligatoryAttendenceYears = table.Column<int>(type: "integer", nullable: true),
                    Financing = table.Column<int>(type: "integer", nullable: true),
                    EndsAt = table.Column<LocalDate>(type: "date", nullable: true),
                    EndReasonCode = table.Column<string>(type: "text", nullable: true),
                    StudyFieldId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsOnInternat = table.Column<bool>(type: "boolean", nullable: true),
                    HasSchoolMeals = table.Column<bool>(type: "boolean", nullable: true),
                    HighestAchievedEducation = table.Column<int>(type: "integer", nullable: false),
                    PreviousEducationCode = table.Column<string>(type: "text", nullable: true),
                    PreviousEducationOperationId = table.Column<Guid>(type: "uuid", nullable: true),
                    ValidSince = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ValidUntil = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDetail_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentDetail_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentDetail_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentDetail_StudyField_StudyFieldId",
                        column: x => x.StudyFieldId,
                        principalTable: "StudyField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentDetail_VirtualOperation_PreviousEducationOperationId",
                        column: x => x.PreviousEducationOperationId,
                        principalTable: "VirtualOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ValidSince = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ValidUntil = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentGroup_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_OperationId",
                table: "Address",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_OperationId",
                table: "Category",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassDetail_ClassId",
                table: "ClassDetail",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassDetail_OperationId",
                table: "ClassDetail",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_ClassId",
                table: "Group",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_EducationFieldId",
                table: "Group",
                column: "EducationFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_OperationId",
                table: "Group",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_OrganizationId",
                table: "Operation",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_UrlName",
                table: "Operation",
                column: "UrlName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_OperationId",
                table: "Person",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_BirthAddressId",
                table: "PersonDetail",
                column: "BirthAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_ContactAddressId",
                table: "PersonDetail",
                column: "ContactAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_OperationId",
                table: "PersonDetail",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_PermanentAddressId",
                table: "PersonDetail",
                column: "PermanentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_PersonId",
                table: "PersonDetail",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_TemporaryAddressId",
                table: "PersonDetail",
                column: "TemporaryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_OperationId",
                table: "Student",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_PersonId",
                table: "Student",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_ClassId",
                table: "StudentDetail",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_OperationId",
                table: "StudentDetail",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_PreviousEducationOperationId",
                table: "StudentDetail",
                column: "PreviousEducationOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_StudentId",
                table: "StudentDetail",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_StudyFieldId",
                table: "StudentDetail",
                column: "StudyFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroup_GroupId",
                table: "StudentGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroup_StudentId",
                table: "StudentGroup",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyField_OperationId",
                table: "StudyField",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualOperation_OperationId",
                table: "VirtualOperation",
                column: "OperationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ClassDetail");

            migrationBuilder.DropTable(
                name: "PersonDetail");

            migrationBuilder.DropTable(
                name: "StudentDetail");

            migrationBuilder.DropTable(
                name: "StudentGroup");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "VirtualOperation");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "StudyField");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
