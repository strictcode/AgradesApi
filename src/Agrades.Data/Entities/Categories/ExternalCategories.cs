 namespace Agrades.Data.Entities.Categories;

public enum CODE_UKON
{
    Succesfull = 1,
    WithoutExam,
    NonPromotionToHigherGrade=4,
    EducationAbandonment
}

public enum Radv
{
    HighSchool = 10,
    HighSchoolWithCertificate = 21,
    ShortenedStudyForHighSchoolCertificate = 22,
    ConservatorySixYearPlan = 31,
    ConservatoryEightYearPlan = 32,
    UniversityWithFieldOfStudy = 34,
    HishSchoolWithGraduation = 41,
    ShortenedStudyForHighSchoolGraduation = 42,
    PostGraduateStudies = 43,
    HighSchoolWithCertificateAndGraduation = 61,
    RequalificationStudiesInKKOVPaidByLabourOffice = 91,
    RequalificationStudiesInKKOVPaidByOtherResources = 92,
}

public enum FinD
{
    SupportMeasureForSchool,
    SupportMeasureForSchoolFacilities,
}

public enum FinA
{
    PersonalSupport,
    ImpairedCommunicationAbility,
    MentalDisability,
    HearingDisability,
    PhysicalDisability,
    DisorderOfAS,
    SpecificBehaviorDis,
    SpecificLearningDis,
    DifferentCulturalAndLivingConditions,
    SeeingDisability,
    SimultaneousImpairmentOfMultipleDefects,
    Gifted,
} 

public enum Rapv
{
    ProperEducation = 1,
    ProperEducationAfterInteruption,
    RepetitionOfGrade,
    ReassignmentToHigherGrareBecauseExceptionalTalent,
    PlacementIntoLowerGradeWithoutRepeating,
    InteruptionOfEducation,
    EducationEnded,
}

public enum Indi
{
    WithoutIVP = 0,
    IvpBecauseSVP = 1,
    IvpBecauseExceptionalyGifted = 5,
    IvpOtherReasons = 9
}

public enum Tt
{
    NormalClass,
    ClassBy16Section9
}

public enum Fn
{
    FundsNotRequired,
    FundsRequired
}

public enum Gifted
{
    NotGifted = 0,
    IsGifted = 1,
}

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

public enum Raun
{
    Passed = 1,
    PassedWithHonors,
    FailedOneSubject,
    FailedMultipleSubjects,
    FailedUnexcusedAbsence
}

public enum TypTr
{
    WithoutAssistent,
    WithOneAssistent,
    WithMultipleAssistents,
}

public enum AdjusteOutputLevel
{
    Without,
    With,
}

public enum DisaA
{
    Without,
    With
}

public enum DisaE
{
    NotGifted,
    Gifted,
    EtroardinaryGifted,
}

public enum Sz
{
    NoSvp,
    SvpBecauseOfCulturalBackground,
    SvpBecauseOfOtherCurcumstances,
    SvpBecauseOfBoth,
}

public enum AdjustedAidLevel
{
    Minor = 1,
    Small = 2,
    Moderate = 3,
    Substantial = 4,
    Significant = 5,
}

public enum Ratt
{
    NormalClass,
    ClassForMentallyDisabled,
    ClassForMediumDisabled,
    ClassForHeavilyDisabled,
    ClassForModeratelyHearingImpaired,
    ClassForHeavilyHearingImpaired,
    ClassForModeratelyVisuallyImpaired,
    ClassForHeavilyVisuallyImpaired,
    ClassForStudentsWithSpeechDisabilities,
    ClassForStudentsWithHeavySpeechDisabilities,
    ClassForHandicapped,
    ClassForHeavyHandicapped,
    ClassForStudentsWithDevelopmentalBehavioralDisorders,
    ClassForStudentsWithHeavyBehavioralDisorders,
    ClassForStudentsWithDevelopmentalLearningDisorders,
    ClassFroStudentsWithMultipleDisabilities,
    ClassForDeafBlind,
    ClassForAutisticStudents,
    ClassForExceptionallyGifted,
    ClassForStudentsInDdAndVuAndDgU,
    ClassNotAssigned
}

public enum Ravz
{
    ExamInRegularTerm = 1,
    ExamInReplacementTerm,
    ReplacementExamAfterRegularOrAlternaticeExam,
    TestRepeat,
    CorrectiveExaminationAfterTestRepeat,
}

public enum Rauv
{
    SuccesfulCompletion = 1,
    CompletionWithoutPrescripedExamination,
    SchoolTransfer,
    FailureToAdvanceBecauseOfFailureToMeetConditionsToTakeTheExam,
    AbandoningEducation,
    ExpelledFromEducation,
    Death,
    TerminationOfEducationForForeigners,
    SchoolTransferBecauseOfMergeOrIZOChangeOr
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

    LightlyDeafIfPOIsNeeded,
    IntermidiateDeaf,
    HeavilyDeaf,
    Deaf,

    LightlyBlindIfPOIsNeeded,
    IntermediatlyBlind,
    HeavilyBlind,
    Blind,

    LightSpeechDefectIfPOIsNeeded,
    IntermediateSpeechDefect,
    HeavySpeechDefect,

    LightPhysicalDisabilityIfPOIsNeeded,
    IntermediatePhysicalDisability,
    HeavyPhysicalDisability,

    LightBehaviourDisorderIfPOIsNeeded,
    IntemediateBehaviourDisorder,
    HeavyBehaviourDisorder,

    LightLearningDisorderIfPOIsNeeded,
    IntermediateLearningDisorder,
    HeavyLearningDisorder,

    OffADS,
    LightADS,
    KidAutism

}