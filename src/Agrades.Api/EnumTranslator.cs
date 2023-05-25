using Agrades.Api.Mapper;
using Agrades.Data.Entities.Categories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Agrades.Api;

public class EnumTranslator
{

}

public static class Tr
{
    public static Rako GetRako(this IAppMapper mapper, string value)
        => (value) switch
        {
            "Osoba bez státního občanství" => Rako.WithoutCitizenship,
            "Občan ČR" => Rako.CzechCitizen,
            "Cizinec s trvalým pobytem v ČR" => Rako.ForeignerWithPermanentResidenceInCz,
            "Cizinec bez trvalého pobytu v ČR" => Rako.ForeignerWithPermanentResidenceInCz,
            "Azylant nebo žadatel o azyl, osoba s doplňkovou nebo dočasnou ochranou v ČR" => Rako.ForeignerWithPermanentResidenceInCz,
            "Občanství neznámé, neudané" => Rako.ForeignerWithPermanentResidenceInCz,
            "Občanství neznámé, neudané" or _ => Rako.Uknown
        };

 

    public static Rakk RakkFromTextToEnum(this IAppMapper mapper, string value)
        => (value) switch
        {
            "Bez vzdělání" => Rakk.WithoutEducation,
            "Základy vzdělání" => Rakk.BasicEducation,
            "Základní vzdělání" => Rakk.ElementaryEducation,
            "Střední vzdělání (bez výučního listu, maturitní zkoušky)" => Rakk.HighSchoolWithoutGraduationOrCertificate,
            "Střední vzdělání s výučním listem" => Rakk.HighSchoolWithCertificate,
            "Střední vzdělání s maturitní zkouškou" => Rakk.HighSchoolWithGraduation,
            "Vyšší odborné vzdělání v konzervatoři" => Rakk.Conservatory,
            "Vyšší odborné vzdělání (ve VOŠ)" => Rakk.UniversityWithFieldOfStudy,
            "Vysokoškolské vzdělání v bakalářském studijním programu" => Rakk.UniversityWithBachelorsDegree,
            "Vysokoškolské vzdělání v magisterském studijním programu" => Rakk.UniversityWithMastersDegree,
            "Vysokoškolské vzdělání v doktorském studijním programu" => Rakk.UniversityWithDoctoralDegree,
            "Ukončený poslední ročník bez maturitní zkoušky" => Rakk.EndedLastSemesterWithoutGraduation
        };
    public static string RakkFromEnumToText(this IAppMapper mapper, Rakk value)
        => (value) switch
        {
            Rakk.WithoutEducation => "Bez vzdělání",
            Rakk.BasicEducation => "Základy vzdělání",
            Rakk.ElementaryEducation => "Zakladní vzdělání",
            Rakk.HighSchoolWithoutGraduationOrCertificate => "Střední vzdělání (bez výučního listu, maturitní zkoušky)",
            Rakk.HighSchoolWithCertificate => "Střední vzdělání s výučním listem",
            Rakk.HighSchoolWithGraduation => "Střední vzdělání s maturitní zkouškou",
            Rakk.Conservatory => "Vyšší odborné vzdělání v konzervatoři",
            Rakk.UniversityWithFieldOfStudy => "Vyšší odborné vzdělání (ve VOŠ)",
            Rakk.UniversityWithBachelorsDegree => "Vysokoškolské vzdělání v bakalářském studijním programu",
            Rakk.UniversityWithMastersDegree => "Vysokoškolské vzdělání v magisterském studijním programu",
            Rakk.UniversityWithDoctoralDegree => "Vysokoškolské vzdělání v doktorském studijním programu",
            Rakk.EndedLastSemesterWithoutGraduation => "Ukončený poslední ročník bez maturitní zkoušky"
        };
    public static string RakkFromEnumToCode(this IAppMapper mapper, Rakk value)
        => (value) switch
        {
            Rakk.WithoutEducation => "1",
            Rakk.BasicEducation => "2",
            Rakk.ElementaryEducation => "3",
            Rakk.HighSchoolWithoutGraduationOrCertificate => "4",
            Rakk.HighSchoolWithCertificate => "5",
            Rakk.HighSchoolWithGraduation => "6",
            Rakk.Conservatory => "7",
            Rakk.UniversityWithFieldOfStudy => "8",
            Rakk.UniversityWithBachelorsDegree => "R",
            Rakk.UniversityWithMastersDegree => "T",
            Rakk.UniversityWithDoctoralDegree => "V",
            Rakk.EndedLastSemesterWithoutGraduation => "X"
        };

    public static Razv RazvFromTextToEnum(this IAppMapper mapper, string value)
        => (value) switch
        {
            "Přijetí do 1.ročníku" => Razv.AdmissionToFirstGrade,
            "Přijetí do 3.ročníku 6letého gymnázia" => Razv.AdmissionToThirdGradeOf6YearGymnasium,
            "Přijetí do 5.ročníku 8letého gymnázia" => Razv.AdmissionToFifthGradeOf8YearGymnasium,
            "Přijetí do vyššího ročníku (podle § 63 resp.§ 95 ŠZ)" => Razv.AdmissionToHigherGrade,
            "Přestup z jiné školy (podle § 66 odst.4 resp.§ 97 odst.5 ŠZ)" => Razv.TransferFromOtherSchool,
            "Přestup z nižššího stupně víceletého gymnázia do 4letého oboru gymnázia" => Razv.TransferFromLowerGradeOfMultiYearGymnasiumTo4YearScopeGymnasium,
            "Převedení z jiné školy (zánik, sloučení škol)" => Razv.TransferFromOtherSchoolAfterTheirMergeOrDemise,
            "Přijetí uprchlíka z Ukrajiny" => Razv.AdmissionOfUkraineRefugee,
            "Zkouška podle § 113c školského zákona" => Razv.ExamBy113cOfSchoolLaw,
            "Zkouška podle § 113d školského zákona" => Razv.ExamBy113dOfSchoolLaw
        };
    public static string RazvFromEnumToCode(this IAppMapper mapper, Razv value)
        => (value) switch
        {
            Razv.AdmissionToFirstGrade => "A",
            Razv.AdmissionToThirdGradeOf6YearGymnasium => "B",
            Razv.AdmissionToFifthGradeOf8YearGymnasium => "C",
            Razv.AdmissionToHigherGrade => "D",
            Razv.TransferFromOtherSchool => "E",
            Razv.TransferFromLowerGradeOfMultiYearGymnasiumTo4YearScopeGymnasium => "F",
            Razv.TransferFromOtherSchoolAfterTheirMergeOrDemise => "H",
            Razv.AdmissionOfUkraineRefugee => "U",
            Razv.ExamBy113cOfSchoolLaw => "Y",
            Razv.ExamBy113dOfSchoolLaw => "Z"
        };
    public static string RazvFromEnumToText(this IAppMapper mapper, Razv value)
        => (value) switch
        {
            Razv.AdmissionToFirstGrade => "Přijetí do 1.ročníku",
            Razv.AdmissionToThirdGradeOf6YearGymnasium => "Přijetí do 3.ročníku 6letého gymnázia",
            Razv.AdmissionToFifthGradeOf8YearGymnasium => "Přijetí do 5.ročníku 8letého gymnázia",
            Razv.AdmissionToHigherGrade => "Přijetí do vyššího ročníku (podle § 63 resp.§ 95 ŠZ)",
            Razv.TransferFromOtherSchool => "Přestup z jiné školy (podle § 66 odst.4 resp.§ 97 odst.5 ŠZ)",
            Razv.TransferFromLowerGradeOfMultiYearGymnasiumTo4YearScopeGymnasium => "Přestup z nižššího stupně víceletého gymnázia do 4letého oboru gymnázia",
            Razv.TransferFromOtherSchoolAfterTheirMergeOrDemise => "Převedení z jiné školy (zánik, sloučení škol)",
            Razv.AdmissionOfUkraineRefugee => "Přijetí uprchlíka z Ukrajiny",
            Razv.ExamBy113cOfSchoolLaw => "Zkouška podle § 113c školského zákona",
            Razv.ExamBy113dOfSchoolLaw => "Zkouška podle § 113d školského zákona"
        };

    public static Rapz RapzFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "Základní škola - z 5.ročníku" => Rapz.ElementarySchoolFifthGrade,
            "Základní škola - ze 6.ročníku" => Rapz.ElementarySchoolSixthGrade,
            "Základní škola - ze 7.ročníku" => Rapz.ElementarySchoolSeventhGrade,
            "Základní škola - z 8.ročníku" => Rapz.ElementarySchoolEighthGrade,
            "Základní škola - z 9.ročníku" => Rapz.ElementarySchoolNinethGrade,
            "Základní škola - z 10.ročníku" => Rapz.ElementarySchoolTenthGrade,
            "Základní škola speciální - z 5.ročníku" => Rapz.ElementarySpecialSchoolFifthGrade,
            "Základní škola speciální - ze 6.ročníku" => Rapz.ElementarySpecialSchoolSixthGrade,
            "Základní škola speciální - ze 7.ročníku" => Rapz.ElementarySpecialSchoolSeventhGrade,
            "Základní škola speciální - z 8.ročníku" => Rapz.ElementarySpecialSchoolEighthGrade,
            "Základní škola speciální - z 9.ročníku" => Rapz.ElementarySpecialSchoolNinethGrade,
            "Základní škola speciální - z 10.ročníku" => Rapz.ElementarySpecialSchoolTenthGrade,
            "Střední škola" => Rapz.HighSchool,
            "Střední škola - víceleté gymnázium - nižší stupeň" => Rapz.HighSchoolMultyYearPlanLowerGrade,
            "Konzervatoř (6letý vzdělávací program)" => Rapz.ConservatorySixYearPlan,
            "Konzervatoř (8letý vzdělávací program) - z 1.-4.ročníku" => Rapz.ConservatoryEightYearPlanLowerGrade,
            "Konzervatoř (8letý vzdělávací program) - z 5.-8.ročníku" => Rapz.ConservatoryEightYearPlanHigherGrade,
            "Vyšší odborná škola" => Rapz.UniversityWithFieldOfStudy,
            "Vysoká škola" => Rapz.College,
            "Zahraniční škola" => Rapz.ForeignSchool,
            "Jiné" => Rapz.Other

        };
    public static string RapzFromEnumToText(this IAppMapper mapper, Rapz value) =>
        (value) switch
        {
            Rapz.ElementarySchoolFifthGrade => "Základní škola - z 5.ročníku",
            Rapz.ElementarySchoolSixthGrade => "Základní škola - ze 6.ročníku",
            Rapz.ElementarySchoolSeventhGrade => "Základní škola - ze 7.ročníku",
            Rapz.ElementarySchoolEighthGrade => "Základní škola - z 8.ročníku",
            Rapz.ElementarySchoolNinethGrade => "Základní škola - z 9.ročníku",
            Rapz.ElementarySchoolTenthGrade => "Základní škola - z 10.ročníku",
            Rapz.ElementarySpecialSchoolFifthGrade => "Základní škola speciální - z 5.ročníku",
            Rapz.ElementarySpecialSchoolSixthGrade => "Základní škola speciální - ze 6.ročníku",
            Rapz.ElementarySpecialSchoolSeventhGrade => "Základní škola speciální - ze 7.ročníku",
            Rapz.ElementarySpecialSchoolEighthGrade => "Základní škola speciální - z 8.ročníku",
            Rapz.ElementarySpecialSchoolNinethGrade => "Základní škola speciální - z 9.ročníku",
            Rapz.ElementarySpecialSchoolTenthGrade => "Základní škola speciální - z 10.ročníku",
            Rapz.HighSchool => "Střední škola",
            Rapz.HighSchoolMultyYearPlanLowerGrade => "Střední škola - víceleté gymnázium - nižší stupeň",
            Rapz.ConservatorySixYearPlan => "Konzervatoř (6letý vzdělávací program)",
            Rapz.ConservatoryEightYearPlanLowerGrade => "Konzervatoř (8letý vzdělávací program) - z 1.-4.ročníku",
            Rapz.ConservatoryEightYearPlanHigherGrade => "Konzervatoř (8letý vzdělávací program) - z 5.-8.ročníku",
            Rapz.UniversityWithFieldOfStudy => "Vyšší odborná škola",
            Rapz.College => "Vysoká škola",
            Rapz.ForeignSchool => "Zahraniční škola",
            Rapz.Other => "Jiné"
        };
    public static string RapzFromEnumToCode(this IAppMapper mapper, Rapz value) =>
        (value) switch
        {
            Rapz.ElementarySchoolFifthGrade => "105",
            Rapz.ElementarySchoolSixthGrade => "106",
            Rapz.ElementarySchoolSeventhGrade => "107",
            Rapz.ElementarySchoolEighthGrade => "108",
            Rapz.ElementarySchoolNinethGrade => "109",
            Rapz.ElementarySchoolTenthGrade => "10A",
            Rapz.ElementarySpecialSchoolFifthGrade => "125",
            Rapz.ElementarySpecialSchoolSixthGrade => "126",
            Rapz.ElementarySpecialSchoolSeventhGrade => "127",
            Rapz.ElementarySpecialSchoolEighthGrade => "128",
            Rapz.ElementarySpecialSchoolNinethGrade => "129",
            Rapz.ElementarySpecialSchoolTenthGrade => "12A",
            Rapz.HighSchool => "200",
            Rapz.HighSchoolMultyYearPlanLowerGrade => "21B",
            Rapz.ConservatorySixYearPlan => "310",
            Rapz.ConservatoryEightYearPlanLowerGrade => "32A",
            Rapz.ConservatoryEightYearPlanHigherGrade => "32B",
            Rapz.UniversityWithFieldOfStudy => "400",
            Rapz.College => "500",
            Rapz.ForeignSchool => "600",
            Rapz.Other => "900"
        };

    public static Rakz RakzFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "Beze změny" => Rakz.WithoutChange,
            "Změna vzdělávání (oboru, druhu, formy, délky)" => Rakz.ChangeOfEducationType,
            "Změna organizace vzdělávání (přestup, přeřazení)" => Rakz.ChangeOrganizationOfStudy,
            "Konání zkoušky (závěrečné,maturitní,absolutoria)" => Rakz.ConductingAnExam,
            "Změna osobních údajů" => Rakz.ChangeOfPersonalInfo,
            "Změna osobního identifikátoru (RČ)" => Rakz.ChangeOfPersonalId,
            "Změna v přiznání/poskytování podpůrných opatření" => Rakz.ChangeInConfessionsOrInProvidingSupportMeasures,
        };
    public static string RakzFromEnumToText(this IAppMapper mapper, Rakz value) =>
        (value) switch
        {
            Rakz.WithoutChange => "Beze změny",
            Rakz.ChangeOfEducationType => "Změna vzdělávání (oboru, druhu, formy, délky)",
            Rakz.ChangeOrganizationOfStudy => "Změna organizace vzdělávání (přestup, přeřazení)",
            Rakz.ConductingAnExam => "Konání zkoušky (závěrečné,maturitní,absolutoria)",
            Rakz.ChangeOfPersonalInfo => "Změna osobních údajů",
            Rakz.ChangeOfPersonalId => "Změna osobního identifikátoru (RČ)",
            Rakz.ChangeInConfessionsOrInProvidingSupportMeasures => "Změna v přiznání/poskytování podpůrných opatření"
        };
    public static string RakzFromEnumToCode(this IAppMapper mapper, Rakz value) => ((int)value).ToString();

    public static Rads RadsFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "Jeden rok" => Rads.OneYear,
            "Jeden a půl roku" => Rads.OneAndAHalfYear,
            "Dva roky" => Rads.TwoYear,
            "Dva a půl roku" => Rads.TwoAndAHalfYear,
            "Tři roky" => Rads.ThreeYear,
            "Tři a půl roku" => Rads.ThreeAndAHalfYear,
            "Čtyři roky" => Rads.FourYear,
            "Čtyři a půl roku" => Rads.FourAndAHalfYear,
            "Pět let" => Rads.FiveYear,
            "Šest let" => Rads.SixYear,
            "Osm let" => Rads.EightYear,
            "Devět let" => Rads.NineYear,
            "Deset let" => Rads.TenYear,
        };
    public static string RadsFromEnumToText(this IAppMapper mapper, Rads value) =>
        (value) switch
        {
            Rads.OneYear => "Jeden rok",
            Rads.OneAndAHalfYear => "Jeden a půl roku",
            Rads.TwoYear => "Dva roky",
            Rads.TwoAndAHalfYear => "Dva a půl roku",
            Rads.ThreeYear => "Tři roky",
            Rads.ThreeAndAHalfYear => "Tři a půl roku",
            Rads.FourYear => "Čtyři roky",
            Rads.FourAndAHalfYear => "Čtyři a půl roku",
            Rads.FiveYear => "Pět let",
            Rads.SixYear => "Šest let",
            Rads.EightYear => "Osm let",
            Rads.NineYear => "Devět let",
            Rads.TenYear => "Deset let",
        };
    public static string RadsFromEnumToCode(this IAppMapper mapper, Rads value) =>
        (value) switch
        {
            Rads.TenYear => "A0",
            _ => ((int)value).ToString(),
        };

    public static Rafs RafsFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "Denní" => Rafs.Daily,
            "Dálková" => Rafs.LongDistance,
            "Večerní" => Rafs.Afternoon,
            "Distanční" => Rafs.Remote,
            "Kombinovaná" => Rafs.Combined,
        };
    public static string RafsFromEnumToText(this IAppMapper mapper, Rafs value) =>
        (value) switch
        {
            Rafs.Daily => "Denní",
            Rafs.LongDistance => "Dálková",
            Rafs.Afternoon => "Večerní",
            Rafs.Remote => "Distanční",
            Rafs.Combined => "Kombinovaná",
        };
    public static string RafsFromEnumToCode(this IAppMapper mapper, Rafs value) => ((int)value).ToString();

    public static Rasd RasdFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "Školní docházka ve škole zapsané ve školském rejstříku" => Rasd.SchoolAttendanceInRegisteredSchool,
            "Souběžné vzdělávání v ZŠ v rámci střídavé péče" => Rasd.CurrentEducationInPrimarySchoolUnderAlternateCare,
            "Plnění PŠD podle § 50 odst.3 ŠZ" => Rasd.FulfillmentOfMSABy50Paragraph3,
            "Plnění PŠD podle § 38 odst. 1, písm. a) ŠZ" => Rasd.FulfillmentOfMSABy38Paragraph1LetterA,
            "Plnění PŠD podle § 38 odst. 1, písm. b) ŠZ" => Rasd.FulfillmentOfMSABy38Paragraph1LetterB,
            "Plnění PŠD podle § 38 odst. 1, písm. c) ŠZ" => Rasd.FulfillmentOfMSABy38Paragraph1LetterC,
            "Plnění PŠD podle § 38 odst. 1, písm. a) ŠZ v tzv. \"evropské škole\"" => Rasd.FulfillmentOfMSABy38Paragraph1LetterD,
            "Individuální výuka v zahraničí podle § 38 odst. 2 ŠZ" => Rasd.IndividualToitionAbroadBy38Paragraph2,
            "Individuální vzdělávání podle § 41 ŠZ" => Rasd.IndividualTuitionBy41

        };

}
