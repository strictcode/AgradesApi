namespace Agrades.Data.Entities.Categories;

public enum Columns
{
    Text,
    Number,
    Bool,
}

public enum Packages
{

}

public enum SchoolGradeType
{
    HighSchool = 200,
}

public enum PersonType
{
    Student = 101,
    Teacher = 201,
    OtherEmployee = 202,
    LegalGuardian = 301,
}

public enum UniqueCodeType
{
    BirthNumber = 101,
    IdentityCardId = 102,
    PassportId = 103,
    Izo = 201,
    RedIzo = 202,
}

public enum FamilyStatus
{
    Single,
    Married,
    Divorced
}

public enum  FieldOfStudyType
{
    ElementarySchool = 100,
    HighSchoolWithLeavingExam = 200
}

public enum Sex
{
    Male = 1,
    Female = 2
}

public enum PersonStatus
{
    Draft = 1,
    Active = 200,
    Inactive = 400,
}

public enum InactivityReason
{
    Graduated = 1,
    Expelled,
    Transfered,
    Deceased
}

public enum ClassType
{
    // 
}

public enum SubjectType
{

}

public enum RelationshipType
{
    Parent,
    LegalGuardian
}

public enum OperationType
{
    // škola, jídelna
}

public enum IvpType
{

}

public enum StartEduReason
{

}

public enum Language
{
    Czech = 1
}
