using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrades.Data.Entities.Categories;

public enum Rasd
{
    SchoolAttendanceInRegisteredSchool = 11,
    CurrentEducationInPrimarySchoolUnderAlternateCare = 12,
    FulfillmentOfMSABy50Paragraph3 = 15,
    FulfillmentOfMSABy38Paragraph1LetterA = 21,
    FulfillmentOfMSABy38Paragraph1LetterB = 22,
    FulfillmentOfMSABy38Paragraph1LetterC = 23,
    IndividualToitionAbroadBy38Paragraph2 = 24,
    FulfillmentOfMSABy38Paragraph1LetterD = 25,
    IndividualTuitionBy41 = 30

}

public enum Rafs
{
    Daily = 10,
    LongDistance = 22,
    Afternoon = 23,
    Remote = 24,
    Combined = 30
}

public enum Rads
{
    OneYear = 10,
    OneAndAHalfYear = 15,
    TwoYear = 20,
    TwoAndAHalfYear = 25,
    ThreeYear = 30,
    ThreeAndAHalfYear = 35,
    FourYear = 40,
    FourAndAHalfYear = 45,
    FiveYear = 50,
    SixYear = 60,
    EightYear = 80,
    NineYear = 90,
    TenYear = 100,
  
}

public enum Rakz
{
    WithoutChange = 0,
    ChangeOfEducationType,
    ChangeOrganizationOfStudy,
    ConductingAnExam = 5,
    ChangeOfPersonalInfo,
    ChangeOfPersonalId,
    ChangeInConfessionsOrInProvidingSupportMeasures,
}
 

public enum Rapz
{
    ElementarySchoolFifthGrade = 1,
    ElementarySchoolSixthGrade,
    ElementarySchoolSeventhGrade,
    ElementarySchoolEighthGrade,
    ElementarySchoolNinethGrade,
    ElementarySchoolTenthGrade,
    ElementarySpecialSchoolFifthGrade,
    ElementarySpecialSchoolSixthGrade,
    ElementarySpecialSchoolSeventhGrade,
    ElementarySpecialSchoolEighthGrade,
    ElementarySpecialSchoolNinethGrade,
    ElementarySpecialSchoolTenthGrade,
    HighSchool,
    HighSchoolMultyYearPlanLowerGrade,
    ConservatorySixYearPlan,
    ConservatoryEightYearPlanLowerGrade,
    ConservatoryEightYearPlanHigherGrade,
    UniversityWithFieldOfStudy,
    College,
    ForeignSchool,
    Other,

}

public enum Rakv
{
    Student = 1,
    Interupted = 2,
    EndedWithoutCopmletion = 3,
    Completed = 4,
    AdditionalPostponment = 5,
    FailedExamByAnonymous = 6,
    PassedExamByAnonymous = 7,
    PersonHaveNotEntered = 9
}

public enum Razv
{
    AdmissionToFirstGrade = 1,
    AdmissionToThirdGradeOf6YearGymnasium ,
    AdmissionToFifthGradeOf8YearGymnasium,
    AdmissionToHigherGrade,
    TransferFromOtherSchool,
    TransferFromLowerGradeOfMultiYearGymnasiumTo4YearScopeGymnasium,
    TransferFromOtherSchoolAfterTheirMergeOrDemise,
    AdmissionOfUkraineRefugee,
    ExamBy113cOfSchoolLaw,
    ExamBy113dOfSchoolLaw
}

public enum Rako
{
    WithoutCitizenship = 0,
    CzechCitizen = 3,
    ForeignerWithPermanentResidenceInCz = 5,
    ForeignerWithoutPermanentResidenceInCz = 6,
    AsylumSeekerWithTemporaryProtectionInCz = 7,
    Uknown = 9
}


public enum Rakk
{
    WithoutEducation = 1,
    BasicEducation,
    ElementaryEducation,
    HighSchoolWithoutGraduationOrCertificate,
    HighSchoolWithCertificate,
    HighSchoolWithGraduation,
    Conservatory,
    UniversityWithFieldOfStudy,
    UniversityWithBachelorsDegree,
    UniversityWithMastersDegree,
    UniversityWithDoctoralDegree,
    EndedLastSemesterWithoutGraduation
}





public enum Raro
{
    FirstGrade = 1,
    SecondGrade,
    ThirdGrade,
    FourthGrade,
    FifthGrade,
    SixthGrade,
    SeventhGrade,
    EightGrade,
    NinthGrade,
    TenthGrade,
    GradeNotAssigned,
}

//translate
public enum Razn
{
    NoDisadvantages = 1,
    ShortTermDisadvantages,
    LongTermDisadvantages,
    LightMentalIllness,
    IntermediateMentalIllness,
    HeavyMentalIllness,
    DeepMentalIllness,
    LightlyDeaf,
    HeavilyDeaf,
    Deaf,
    LightlyBlind,
    IntermediatlyBlind,
    HeavilyBlind,
    Blind,
    LightSpeechDefect,
    IntermediateSpeechDefect,
    HeavySpeechDefect,
    LightPhysicalDisability,
    IntermediatePhysicalDisability,
    HeavyPhysicalDisability,
    LightBehaviourDisorder,
    IntemediateBehaviourDisorder,
    HeavyBehaviourDisorder,
    LightLearningDisorder,
    IntermediateLearningDisorder,
    OffADS,
    LightADS,
    KidAutism

}