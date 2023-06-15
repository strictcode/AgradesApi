using Agrades.Api.Mapper;
using Agrades.Data.Entities.Categories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.CompilerServices;

namespace Agrades.Api;

public class EnumTranslator
{

}

public static class Tr
{
    public static string GetIdOfDisString(this IAppMapper mapper, IdOfDisadvantage ids)
    {
        var b = ids.Ff != null ? mapper.RaznFromEnumToCode((Razn)ids.Ff) : string.Empty;
        var c = ids.Ff != null ? mapper.RaznFromEnumToCode((Razn)ids.Ff) : string.Empty;
        var d = ids.D != null ? mapper.SzFromEnumToCode((Sz)ids.D) : string.Empty;
        var h = ids.Ff != null ? mapper.RaznFromEnumToCode((Razn)ids.Ff) : string.Empty;
        var f = ids.Ff != null ? mapper.RaznFromEnumToCode((Razn)ids.Ff) : string.Empty;
        var g = ids.Ff != null ? mapper.RaznFromEnumToCode((Razn)ids.Ff) : string.Empty;
        return $"{ids.A}{b}{c}{d}{ids.Ee}{f}{g}{h}";
    }

    public static string GetIdOfFinString(this IAppMapper mapper, IdOfFinancialDemands id)
    {
        var a = mapper.FinAFromEnumToCode(id.A);
        var d = mapper.FinDCodeFromEnum(id.D);
        return $"{a}{id.B}{id.Cccc}{id.D}{id.Ee}";


    }

    public static IdOfFinancialDemands GetIdOfFinancialDemands(this IAppMapper mapper, string value)
    {
        var splited = value.ToArray();
        var output = new IdOfFinancialDemands();
        output.A = mapper.FinAFromCodeToEnum(splited[0].ToString());
        output.B = splited[1].ToString();
        output.Cccc = value.Substring(1, 4);
        output.D = mapper.FinDEnumFromCode(splited[6].ToString());
        output.Ee = value.Substring(7, 2);
        return output;
    }

    public static FinD FinDEnumFromCode(this IAppMapper mapper, string value) =>
        value switch
        {
            "A" => FinD.SupportMeasureForSchool,
            "B" => FinD.SupportMeasureForSchoolFacilities,
        };

    public static string FinDCodeFromEnum(this IAppMapper mapper, FinD value) =>
        value switch
        {
            FinD.SupportMeasureForSchool => "A",
            FinD.SupportMeasureForSchoolFacilities => "B",
        };

    public static string FinAFromEnumToCode(this IAppMapper mapper, FinA value) =>
        (value) switch
        {
            FinA.PersonalSupport => "0",
            FinA.ImpairedCommunicationAbility => "A",
            FinA.MentalDisability => "B",
            FinA.HearingDisability => "C",
            FinA.PhysicalDisability => "D",
            FinA.DisorderOfAS => "E",
            FinA.SpecificBehaviorDis => "F",
            FinA.SpecificLearningDis => "G",
            FinA.DifferentCulturalAndLivingConditions => "H",
            FinA.SeeingDisability => "I",
            FinA.SimultaneousImpairmentOfMultipleDefects => "J",
            FinA.Gifted => "K",
        };
    public static FinA FinAFromCodeToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "0" => FinA.PersonalSupport,
            "A" => FinA.ImpairedCommunicationAbility,
            "B" => FinA.MentalDisability,
            "C" => FinA.HearingDisability,
            "D" => FinA.PhysicalDisability,
            "E" => FinA.DisorderOfAS,
            "F" => FinA.SpecificBehaviorDis,
            "G" => FinA.SpecificLearningDis,
            "H" => FinA.DifferentCulturalAndLivingConditions,
            "I" => FinA.SeeingDisability,
            "J" => FinA.SimultaneousImpairmentOfMultipleDefects,
            "K" => FinA.Gifted,
        };

    public static int Parse(string value) => int.TryParse(value, out var x) ? x : 0;
    public static IdOfDisadvantage GetIdOfDisadvantageFromString(this IAppMapper mapper, string value)
    {
        var splited = value.ToArray();
        var output = new IdOfDisadvantage();
        output.A = (DisaA)Parse(splited[0].ToString());
        output.Bb = mapper.RaznFromCodeToEnum(value.Substring(1, 2));
        output.Cc = mapper.RaznFromCodeToEnum(value.Substring(3, 2));
        output.D = mapper.SzFromCodeToEnum(splited[5].ToString());
        output.Ee = (DisaE)Parse(splited[6].ToString());
        if (splited.Length > 7)
        {
            output.Ff = mapper.RaznFromCodeToEnum(value.Substring(7, 2));
        }
        if (splited.Length > 9)
        {
            output.Hh = mapper.RaznFromCodeToEnum(value.Substring(9, 2));
        }
        if (splited.Length > 11)
        {
            output.Gg = mapper.RaznFromCodeToEnum(value.Substring(11, 2));
        }
        return output;
    }
    public static Sz SzFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "nemá SVP vyplývající z odlišného kulturního prostředí nebo jiných životních podmínek" => Sz.NoSvp,
            "SVP vyplývají převážně z odlišného kulturního prostředí žáka" => Sz.SvpBecauseOfCulturalBackground,
            "SVP vyplývají převážně z dopadu jiných životních podmínek žáka do vzdělávání" => Sz.SvpBecauseOfOtherCurcumstances,
            "SVP vyplývají z více faktorů uvedených pod body K a Z" => Sz.SvpBecauseOfBoth,
        };

    public static Sz SzFromCodeToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "0" => Sz.NoSvp,
            "K" => Sz.SvpBecauseOfCulturalBackground,
            "Z" => Sz.SvpBecauseOfOtherCurcumstances,
            "V" => Sz.SvpBecauseOfBoth,
        };
    public static string SzFromEnumToCode(this IAppMapper mapper, Sz value) =>
        (value) switch
        {
            Sz.NoSvp => "0",
            Sz.SvpBecauseOfCulturalBackground => "K",
            Sz.SvpBecauseOfOtherCurcumstances => "Z",
            Sz.SvpBecauseOfBoth => "V",
        };

    public static Razn RaznFromCodeToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "00" => Razn.NoDisadvantages,
            "0M" => Razn.ShortTermDisadvantages,
            "0T" => Razn.LongTermDisadvantages,
            "1M" => Razn.LightMentalIllness,
            "1S" => Razn.IntermediateMentalIllness,
            "1T" => Razn.HeavyMentalIllness,
            "1Y" => Razn.DeepMentalIllness,
            "2M" => Razn.LightlyDeafIfPOIsNeeded,
            "2S" => Razn.IntermidiateDeaf,
            "2T" => Razn.HeavilyDeaf,
            "2Y" => Razn.Deaf,
            "3M" => Razn.LightlyBlindIfPOIsNeeded,
            "3S" => Razn.IntermediatlyBlind,
            "3T" => Razn.HeavilyBlind,
            "3Y" => Razn.Blind,
            "4M" => Razn.LightSpeechDefectIfPOIsNeeded,
            "4S" => Razn.IntermediateSpeechDefect,
            "4T" => Razn.HeavySpeechDefect,
            "5M" => Razn.LightPhysicalDisabilityIfPOIsNeeded,
            "5S" => Razn.IntermediatePhysicalDisability,
            "5T" => Razn.HeavyPhysicalDisability,
            "6M" => Razn.LightBehaviourDisorderIfPOIsNeeded,
            "6S" => Razn.IntemediateBehaviourDisorder,
            "6T" => Razn.HeavyBehaviourDisorder,
            "7M" => Razn.LightLearningDisorderIfPOIsNeeded,
            "7S" => Razn.IntermediateLearningDisorder,
            "7T" => Razn.HeavyLearningDisorder,
            "8J" => Razn.OffADS,
            "8M" => Razn.LightADS,
            "8T" => Razn.KidAutism,
        };

    public static string RaznFromEnumToCode(this IAppMapper mapper, Razn value) =>
        (value) switch
        {
            Razn.NoDisadvantages => "00",
            Razn.ShortTermDisadvantages => "0M",
            Razn.LongTermDisadvantages => "0T",
            Razn.LightMentalIllness => "1M",
            Razn.IntermediateMentalIllness => "1S",
            Razn.HeavyMentalIllness => "1T",
            Razn.DeepMentalIllness => "1Y",
            Razn.LightlyDeafIfPOIsNeeded => "2M",
            Razn.IntermidiateDeaf => "2S",
            Razn.HeavilyDeaf => "2T",
            Razn.Deaf => "2Y",
            Razn.LightlyBlindIfPOIsNeeded => "3M",
            Razn.IntermediatlyBlind => "3S",
            Razn.HeavilyBlind => "3T",
            Razn.Blind => "3Y",
            Razn.LightSpeechDefectIfPOIsNeeded => "4M",
            Razn.IntermediateSpeechDefect => "4S",
            Razn.HeavySpeechDefect => "4T",
            Razn.LightPhysicalDisabilityIfPOIsNeeded => "5M",
            Razn.IntermediatePhysicalDisability => "5S",
            Razn.HeavyPhysicalDisability => "5T",
            Razn.LightBehaviourDisorderIfPOIsNeeded => "6M",
            Razn.IntemediateBehaviourDisorder => "6S",
            Razn.HeavyBehaviourDisorder => "6T",
            Razn.LightLearningDisorderIfPOIsNeeded => "7M",
            Razn.IntermediateLearningDisorder => "7S",
            Razn.HeavyLearningDisorder => "7T",
            Razn.OffADS => "8J",
            Razn.LightADS => "8M",
            Razn.KidAutism => "8T",
        };


    public static string RaznFromEnumToText(this IAppMapper mapper, Razn value) =>
        (value) switch
        {
            Razn.NoDisadvantages => "Bez (dalšího) znevýhodnění",
            Razn.ShortTermDisadvantages => "Krátkodobé SVP vyplýv. ze zdrav. stavu či jiných okolností, mimo 1M až 8T",
            Razn.LongTermDisadvantages => "Dlouhodobé SVP vyplýv. ze zdrav. stavu či jiných okolností, mimo 1M až 8T",
            Razn.LightMentalIllness => "Lehké mentální postižení",
            Razn.IntermediateMentalIllness => "Středně těžké mentální postižení",
            Razn.HeavyMentalIllness => "Těžké mentální postižení",
            Razn.DeepMentalIllness => "Hluboké mentální postižení",
            Razn.LightlyDeafIfPOIsNeeded => "Mírné sluchové postižení, pokud vyžaduje PO",
            Razn.IntermidiateDeaf => "Středně těžké sluchové postižení",
            Razn.HeavilyDeaf => "Těžké sluchové postižení",
            Razn.Deaf => "Neslyšící",
            Razn.LightlyBlindIfPOIsNeeded => "Mírné zrakové postižení, pokud vyžaduje PO",
            Razn.IntermediatlyBlind => "Středně těžké zrakové postižení",
            Razn.HeavilyBlind => "Těžké zrakové postižení",
            Razn.Blind => "Nevidomí",
            Razn.LightSpeechDefectIfPOIsNeeded => "Mírné vady řeči, pokud vyžadují PO",
            Razn.IntermediateSpeechDefect => "Středně závažné vady řeči",
            Razn.HeavySpeechDefect => "Závažné vady řeči",
            Razn.LightPhysicalDisabilityIfPOIsNeeded => "Mírné tělesné postižení, pokud vyžaduje PO",
            Razn.IntermediatePhysicalDisability => "Středně těžké tělesné postižení",
            Razn.HeavyPhysicalDisability => "Těžké tělesné postižení",
            Razn.LightBehaviourDisorderIfPOIsNeeded => "Mírné poruchy chování, pokud vyžadují PO",
            Razn.IntemediateBehaviourDisorder => "Středně závažné poruchy chování",
            Razn.HeavyBehaviourDisorder => "Závažné poruchy chování",
            Razn.LightLearningDisorderIfPOIsNeeded => "Mírné poruchy učení, pokud vyžadují PO",
            Razn.IntermediateLearningDisorder => "Středně závažné poruchy učení",
            Razn.HeavyLearningDisorder => "Závažné poruchy učení",
            Razn.OffADS => "Poruchy autist. spektra mimo dětského autismu se závažným odrazem do vzdělávání",
            Razn.LightADS => "Poruchy autistického spektra s mírným odrazem do vzdělávání žáka",
            Razn.KidAutism => "Dětský autismus (se závažným odrazem do vzdělávání žáka)",
        };

    public static TypTr TypTrFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "třída bez asistenta pedagoga" => TypTr.WithoutAssistent,
            "třída s jedním asistentem pedagoga nebo s jedním vychovatelem" => TypTr.WithOneAssistent,
            "třída s více asistenty nebo s asistentem a vychovatelem" => TypTr.WithMultipleAssistents
        };

    public static string TypTrFromTEnumToText(this IAppMapper mapper, TypTr value) =>
        (value) switch
        {
            TypTr.WithoutAssistent => "třída bez asistenta pedagoga",
            TypTr.WithOneAssistent => "třída s jedním asistentem pedagoga nebo s jedním vychovatelem",
            TypTr.WithMultipleAssistents => "třída s více asistenty nebo s asistentem a vychovatelem"
        };
    public static string TypTrFromEnumToCode(this IAppMapper mapper, TypTr value) =>
        (value) switch
        {
            TypTr.WithoutAssistent => "A0",
            TypTr.WithOneAssistent => "A1",
            TypTr.WithMultipleAssistents => "A2"
        };

    public static AdjusteOutputLevel AdjusteOutputLevelFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "bez úpravy výstupů" => AdjusteOutputLevel.Without,
            "upravené výstupy vzdělávání" => AdjusteOutputLevel.With,
        };

    public static string AdjusteOutputLevelFromTextToEnum(this IAppMapper mapper, AdjusteOutputLevel value) =>
        (value) switch
        {
            AdjusteOutputLevel.Without => "bez úpravy výstupů",
            AdjusteOutputLevel.With => "upravené výstupy vzdělávání",
        };

    public static Fn FnFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "finanční prostředky nepožadovány" => Fn.FundsNotRequired,
            "finanční prostředky požadovány" => Fn.FundsRequired
        };
    public static string FnFromEnumToText(this IAppMapper mapper, Fn value) =>
        (value) switch
        {
            Fn.FundsNotRequired => "finanční prostředky nepožadovány",
            Fn.FundsRequired => "finanční prostředky požadovány"
        };

    public static Radv RadvFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "Střední" => Radv.HighSchool,
            "Střední s výučním listem" => Radv.HighSchoolWithCertificate,
            "Zkrácené studium pro získání středního vzdělání s výučním listem" => Radv.ShortenedStudyForHighSchoolCertificate,
            "Vyšší odborné v konzervatoři -6leté" => Radv.ConservatorySixYearPlan,
            "Vyšší odborné v konzervatoři - 8leté" => Radv.ConservatoryEightYearPlan,
            "Vyšší odborné ve VOŠ" => Radv.UniversityWithFieldOfStudy,
            "Střední s maturitní zkouškou" => Radv.HishSchoolWithGraduation,
            "Zkrácené studium pro získání středního vzdělání s maturitní zkouškou" => Radv.ShortenedStudyForHighSchoolGraduation,
            "Nástavbové studium" => Radv.PostGraduateStudies,
            "Střední s maturitní zkouškou i výučním listem" => Radv.HighSchoolWithCertificateAndGraduation,
            "Rekvalifikační studium v oboru KKOV, hrazené úřadem práce" => Radv.RequalificationStudiesInKKOVPaidByLabourOffice,
            "Rekvalifikační studium v oboru KKOV, hrazené z jiných zdrojů" => Radv.RequalificationStudiesInKKOVPaidByOtherResources,
        };

    public static string RadvFromEnumToText(this IAppMapper mapper, Radv value) =>
        (value) switch
        {
            Radv.HighSchool => "Střední",
            Radv.HighSchoolWithCertificate => "Střední s výučním listem",
            Radv.ShortenedStudyForHighSchoolCertificate => "Zkrácené studium pro získání středního vzdělání s výučním listem",
            Radv.ConservatorySixYearPlan => "Vyšší odborné v konzervatoři -6leté",
            Radv.ConservatoryEightYearPlan => "Vyšší odborné v konzervatoři - 8leté",
            Radv.UniversityWithFieldOfStudy => "Vyšší odborné ve VOŠ",
            Radv.HishSchoolWithGraduation => "Střední s maturitní zkouškou",
            Radv.ShortenedStudyForHighSchoolGraduation => "Zkrácené studium pro získání středního vzdělání s maturitní zkouškou",
            Radv.PostGraduateStudies => "Nástavbové studium",
            Radv.HighSchoolWithCertificateAndGraduation => "Střední s maturitní zkouškou i výučním listem",
            Radv.RequalificationStudiesInKKOVPaidByLabourOffice => "Rekvalifikační studium v oboru KKOV, hrazené úřadem práce",
            Radv.RequalificationStudiesInKKOVPaidByOtherResources => "Rekvalifikační studium v oboru KKOV, hrazené z jiných zdrojů",
        };

    public static Gifted GiftedFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "bez nadání" => Gifted.NotGifted,
            "nadaný žák" => Gifted.IsGifted,

        };
    public static string GiftedFromEnumToText(this IAppMapper mapper, Gifted value) =>
        (value) switch
        {
            Gifted.NotGifted => "bez nadání",
            Gifted.IsGifted => "nadaný žák",

        };

    public static Rapv RapvFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "Řádné vzdělávání" => Rapv.ProperEducation,
            "Řádné vzdělávání po přerušení vzdělávání" => Rapv.ProperEducationAfterInteruption,
            "Opakování ročníku" => Rapv.RepetitionOfGrade,
            "Přeřazení do vyššího ročníku (z důvodu mimořádného nadání)" => Rapv.ReassignmentToHigherGrareBecauseExceptionalTalent,
            "Zařazení do nižšího ročníku (bez opakování)" => Rapv.PlacementIntoLowerGradeWithoutRepeating,
            "Přerušení vzdělávání" => Rapv.InteruptionOfEducation,
            "Vzdělávání ukončeno" => Rapv.EducationEnded,
        };
    public static string RapvFromEnumToText(this IAppMapper mapper, Rapv value) =>
        (value) switch
        {
            Rapv.ProperEducation => "Řádné vzdělávání",
            Rapv.ProperEducationAfterInteruption => "Řádné vzdělávání po přerušení vzdělávání",
            Rapv.RepetitionOfGrade => "Opakování ročníku",
            Rapv.ReassignmentToHigherGrareBecauseExceptionalTalent => "Přeřazení do vyššího ročníku (z důvodu mimořádného nadání)",
            Rapv.PlacementIntoLowerGradeWithoutRepeating => "Zařazení do nižšího ročníku (bez opakování)",
            Rapv.InteruptionOfEducation => "Přerušení vzdělávání",
            Rapv.EducationEnded => "Vzdělávání ukončeno",
        };

    public static Ratt RattFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "Běžná třída/studijní skupina" => Ratt.NormalClass,
            "Třída pro lehce mentálně postižené" => Ratt.ClassForMentallyDisabled,
            "Třída pro středně mentálně postižené" => Ratt.ClassForMediumDisabled,
            "Třída pro těžce mentálně postižené" => Ratt.ClassForHeavilyDisabled,
            "Třída/studijní skupina pro středně těžce sluchově postižené" => Ratt.ClassForModeratelyHearingImpaired,
            "Třída/studijní skupina pro těžce sluchově postižené" => Ratt.ClassForHeavilyHearingImpaired,
            "Třída/studijní skupina pro středně těžce zrakově postižené" => Ratt.ClassForModeratelyVisuallyImpaired,
            "Třída/studijní skupina pro těžce zrakově postižené" => Ratt.ClassForHeavilyVisuallyImpaired,
            "Třída pro žáky s vadami řeči" => Ratt.ClassForStudentsWithSpeechDisabilities,
            "Třída pro žáky s těžkou vadou řeči" => Ratt.ClassForStudentsWithHeavySpeechDisabilities,
            "Třída/studijní skupina pro tělesně postižené" => Ratt.ClassForHandicapped,
            "Třída pro žáky s těžkým tělesným postižením" => Ratt.ClassForHeavyHandicapped,
            "Třída pro žáky s vývojovými poruchami chování" => Ratt.ClassForStudentsWithDevelopmentalBehavioralDisorders,
            "Třída pro žáky s těžkými poruchami chování" => Ratt.ClassForStudentsWithHeavyBehavioralDisorders,
            "Třída pro žáky s vývojovými poruchami učení" => Ratt.ClassForStudentsWithDevelopmentalLearningDisorders,
            "Třída/studijní skupina pro žáky/studenty se souběžným postižením více vadami" => Ratt.ClassFroStudentsWithMultipleDisabilities,
            "Třída/ studijní skupina pro hluchoslepé" => Ratt.ClassForDeafBlind,
            "Třída/studijní skupina pro autistické žáky/studenty" => Ratt.ClassForAutisticStudents,
            "Třída pro mimořádně nadané" => Ratt.ClassForExceptionallyGifted,
            "Třída pro žáky v DD se školou, VÚ, DgÚ" => Ratt.ClassForStudentsInDdAndVuAndDgU,
            "Nezařazen do třídy" => Ratt.ClassNotAssigned,
        };
    public static string RattFromEnumToText(this IAppMapper mapper, Ratt value) =>
        (value) switch
        {
            Ratt.NormalClass => "Běžná třída/studijní skupina",
            Ratt.ClassForMentallyDisabled => "Třída pro lehce mentálně postižené",
            Ratt.ClassForMediumDisabled => "Třída pro středně mentálně postižené",
            Ratt.ClassForHeavilyDisabled => "Třída pro těžce mentálně postižené",
            Ratt.ClassForModeratelyHearingImpaired => "Třída/studijní skupina pro středně těžce sluchově postižené",
            Ratt.ClassForHeavilyHearingImpaired => "Třída/studijní skupina pro těžce sluchově postižené",
            Ratt.ClassForModeratelyVisuallyImpaired => "Třída/studijní skupina pro středně těžce zrakově postižené",
            Ratt.ClassForHeavilyVisuallyImpaired => "Třída/studijní skupina pro těžce zrakově postižené",
            Ratt.ClassForStudentsWithSpeechDisabilities => "Třída pro žáky s vadami řeči",
            Ratt.ClassForStudentsWithHeavySpeechDisabilities => "Třída pro žáky s těžkou vadou řeči",
            Ratt.ClassForHandicapped => "Třída/studijní skupina pro tělesně postižené",
            Ratt.ClassForHeavyHandicapped => "Třída pro žáky s těžkým tělesným postižením",
            Ratt.ClassForStudentsWithDevelopmentalBehavioralDisorders => "Třída pro žáky s vývojovými poruchami chování",
            Ratt.ClassForStudentsWithHeavyBehavioralDisorders => "Třída pro žáky s těžkými poruchami chování",
            Ratt.ClassForStudentsWithDevelopmentalLearningDisorders => "Třída pro žáky s vývojovými poruchami učení",
            Ratt.ClassFroStudentsWithMultipleDisabilities => "Třída/studijní skupina pro žáky/studenty se souběžným postižením více vadami",
            Ratt.ClassForDeafBlind => "Třída/ studijní skupina pro hluchoslepé",
            Ratt.ClassForAutisticStudents => "Třída/studijní skupina pro autistické žáky/studenty",
            Ratt.ClassForExceptionallyGifted => "Třída pro mimořádně nadané",
            Ratt.ClassForStudentsInDdAndVuAndDgU => "Třída pro žáky v DD se školou, VÚ, DgÚ",
            Ratt.ClassNotAssigned => "Nezařazen do třídy",
        };

    public static string RattFromEnumToCode(this IAppMapper mapper, Ratt value) =>
        (value) switch
        {
            Ratt.NormalClass => "100",
            Ratt.ClassForMentallyDisabled => "11L",
            Ratt.ClassForMediumDisabled => "11S",
            Ratt.ClassForHeavilyDisabled => "11T",
            Ratt.ClassForModeratelyHearingImpaired => "12S",
            Ratt.ClassForHeavilyHearingImpaired => "12T",
            Ratt.ClassForModeratelyVisuallyImpaired => "13S",
            Ratt.ClassForHeavilyVisuallyImpaired => "13T",
            Ratt.ClassForStudentsWithSpeechDisabilities => "14S",
            Ratt.ClassForStudentsWithHeavySpeechDisabilities => "14T",
            Ratt.ClassForHandicapped => "15S",
            Ratt.ClassForHeavyHandicapped => "15T",
            Ratt.ClassForStudentsWithDevelopmentalBehavioralDisorders => "16S",
            Ratt.ClassForStudentsWithHeavyBehavioralDisorders => "16T",
            Ratt.ClassForStudentsWithDevelopmentalLearningDisorders => "16U",
            Ratt.ClassFroStudentsWithMultipleDisabilities => "17A",
            Ratt.ClassForDeafBlind => "17B",
            Ratt.ClassForAutisticStudents => "18A",
            Ratt.ClassForExceptionallyGifted => "300",
            Ratt.ClassForStudentsInDdAndVuAndDgU => "590",
            Ratt.ClassNotAssigned => "900",
        };

    public static Ravz RavzFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "Zkouška v řádném termínu" => Ravz.ExamInRegularTerm,
            "Náhradní zkouška" => Ravz.ExamInReplacementTerm,
            "Opravná zkouška (po řádné nebo náhradní zkoušce)" => Ravz.ReplacementExamAfterRegularOrAlternaticeExam,
            "Opakovaná zkouška" => Ravz.TestRepeat,
            "Opravná zkouška (po opakované zkoušce)" => Ravz.CorrectiveExaminationAfterTestRepeat,
        };

    public static string RavzFromEnumToText(this IAppMapper mapper, Ravz value) =>
        (value) switch
        {
            Ravz.ExamInRegularTerm => "Zkouška v řádném termínu",
            Ravz.ExamInReplacementTerm => "Náhradní zkouška",
            Ravz.ReplacementExamAfterRegularOrAlternaticeExam => "Opravná zkouška (po řádné nebo náhradní zkoušce)",
            Ravz.TestRepeat => "Opakovaná zkouška",
            Ravz.CorrectiveExaminationAfterTestRepeat => "Opravná zkouška (po opakované zkoušce)",
        };

    public static Rauv RauvFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "Úspěšné absolvování" => Rauv.SuccesfulCompletion,
            "Ukončení vzdělávacího programu bez předepsané zkoušky" => Rauv.CompletionWithoutPrescripedExamination,
            "Přestup na jinou školu" => Rauv.SchoolTransfer,
            "Nepostoupení do vyššího ročníku, nesplnění podmínek pro konání zkoušky" => Rauv.FailureToAdvanceBecauseOfFailureToMeetConditionsToTakeTheExam,
            "Zanechání vzdělávání" => Rauv.AbandoningEducation,
            "Vyloučení" => Rauv.ExpelledFromEducation,
            "Úmrtí" => Rauv.Death,
            "Ukončení pro cizince (odstěhování)" => Rauv.TerminationOfEducationForForeigners,
            "Převední do jiné školy (sloučení škol, splynutí, změna IZO)" => Rauv.SchoolTransferBecauseOfMergeOrIZOChangeOr,
        };

    public static Raun RaunFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "Prospěl" => Raun.Passed,
            "Prospěl s vyznamenáním" => Raun.PassedWithHonors,
            "Neprospěl z jednoho předmětu" => Raun.FailedOneSubject,
            "Neprospěl z více předmětů" => Raun.FailedMultipleSubjects,
            "Neprospěl - neomluvená neúčast" => Raun.FailedUnexcusedAbsence,
        };

    public static string RaunFromTextToEnum(this IAppMapper mapper, Raun value) =>
        (value) switch
        {
            Raun.Passed => "Prospěl",
            Raun.PassedWithHonors => "Prospěl s vyznamenáním",
            Raun.FailedOneSubject => "Neprospěl z jednoho předmětu",
            Raun.FailedMultipleSubjects => "Neprospěl z více předmětů",
            Raun.FailedUnexcusedAbsence => "Neprospěl - neomluvená neúčast",
        };

    public static Indi IndiFromTextToEnum(this IAppMapper mapper, string value) =>
        (value) switch
        {
            "bez IVP" => Indi.WithoutIVP,
            "Ivp z důvodu SVP" => Indi.IvpBecauseSVP,
            "Ivp - mimořádné nadání" => Indi.IvpBecauseExceptionalyGifted,
            "Ivp - ostatní" => Indi.IvpOtherReasons,
        };

    public static string IndiFromEnumToText(this IAppMapper mapper, Indi value) =>
        (value) switch
        {
            Indi.WithoutIVP => "bez IVP",
            Indi.IvpBecauseSVP => "Ivp z důvodu SVP",
            Indi.IvpBecauseExceptionalyGifted => "Ivp - mimořádné nadání",
            Indi.IvpOtherReasons => "Ivp - ostatní",
        };

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
            "Přijetí do vyššího ročníku (podle § 63 resp. § 95 ŠZ)" => Razv.AdmissionToHigherGrade,
            //"Přijetí do vyššího ročníku (podle § 63 resp. § 95 ŠZ)"
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
