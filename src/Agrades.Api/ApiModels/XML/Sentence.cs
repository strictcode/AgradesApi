using Agrades.Api.Mapper;
using Agrades.Data.Entities.Persons;
using System.Xml.Serialization;

namespace Agrades.Api.ApiModels.XML;

public class Sentence
{
    /// <summary>
    /// 
    /// </summary>
    [XmlAttribute(AttributeName = "RDAT")]
    public string DecisiveCollectionDate { get; set; } = null!;

    [XmlAttribute(AttributeName = "IZO")]
    public string Izo { get; set; } = null!;

    [XmlAttribute(AttributeName = "CAST")]
    public string OperationPart { get; set; } = null!;

    [XmlAttribute(AttributeName = "RODC")]
    public string BirthNumber { get; set; } = null!;

    [XmlAttribute(AttributeName = "POHLAVI")]
    public string Sex { get; set; } = null!;

    [XmlAttribute(AttributeName = "DAT_NAROZ")]
    public string BirthDate { get; set; } = null!;

    [XmlAttribute(AttributeName = "KSTPR")]
    public string CitizenshtipQualifier { get; set; } = null!;

    [XmlAttribute(AttributeName = "STPR")]
    public string Citizenship { get; set; } = null!;

    /// <summary>
    /// Obec
    /// </summary>
    [XmlAttribute(AttributeName = "OBECB")]
    public string Municipality { get; set; } = null!;

    [XmlAttribute(AttributeName = "OKRESB")]
    public string District { get; set; } = null!;

    [XmlAttribute(AttributeName = "ODHL")]
    public string PreviousEducation { get; set; } = null!;

    [XmlAttribute(AttributeName = "IZOZ")]
    public string PreviousEducationIzo { get; set; } = null!;

    //[XmlAttribute(AttributeName = "IZOS")]
    //public string PreviousLeavingExamIzo { get; set; } = null!;

    // ///<summary>
    // ///HVS - vyšší odborná škola
    // ///</summary>
    //[XmlAttribute(AttributeName = "OBORS")]
    //public string HvsStudyFieldCode { get; set; } = null!;

    [XmlAttribute(AttributeName = "STUPEN")]
    public string HighestAchievedEducation { get; set; } = null!;

    [XmlAttribute(AttributeName = "ZAHDAT")]
    public string EducationStart { get; set; } = null!;

    [XmlAttribute(AttributeName = "KOD_ZAH")]
    public string EducationStartCode { get; set; } = null!;

    [XmlAttribute(AttributeName = "UKONDAT")]
    public string EducationEnd { get; set; } = null!;

    [XmlAttribute(AttributeName = "KOD_UKON")]
    public string EducationEndCode { get; set; } = null!;

    [XmlAttribute(AttributeName = "ROCNIK")]
    public string Grade { get; set; } = null!;

    [XmlAttribute(AttributeName = "TRIDA")]
    public string Class { get; set; } = null!;

    [XmlAttribute(AttributeName = "ST_SKOLY")]
    public string SchoolGradeType { get; set; } = null!;

    [XmlAttribute(AttributeName = "ZPUSOB")]
    public string Form { get; set; } = null!;

    [XmlAttribute(AttributeName = "PRIZN_ST")]
    public string EducationQualifier { get; set; } = null!;

    [XmlAttribute(AttributeName = "PRERUS")]
    public string Interuption { get; set; } = null!;

    [XmlAttribute(AttributeName = "FIN")]
    public string Financing { get; set; } = null!;

    [XmlAttribute(AttributeName = "OBOR")]
    public string StudyField { get; set; } = null!;
    /*
    [XmlAttribute(AttributeName = "OBOR2")]
    public string StudyField2 { get; set; } = null!;
    */
    [XmlAttribute(AttributeName = "DELST")]
    public string EducationLength { get; set; } = null!;

    [XmlAttribute(AttributeName = "FST")]
    public string EducationType { get; set; } = null!;

    [XmlAttribute(AttributeName = "LET_PSD")]
    public string MandatoryYears { get; set; } = null!;

    [XmlAttribute(AttributeName = "JAZYK_O")]
    public string LanguageStudy { get; set; } = null!;

    [XmlAttribute(AttributeName = "JAZ1")]
    public string Language1Code { get; set; } = null!;
    /*
    [XmlAttribute(AttributeName = "P_JAZ1")]
    public string Language1Qualifier { get; set; } = null!;
    */
    [XmlAttribute(AttributeName = "JAZ2")]
    public string Language2Code { get; set; } = null!;
    /*
    [XmlAttribute(AttributeName = "P_JAZ2")]
    public string Language2Qualifier { get; set; } = null!;
    */
    [XmlAttribute(AttributeName = "JAZ3")]
    public string Language3Code { get; set; } = null!;
    /*
    [XmlAttribute(AttributeName = "P_JAZ3")]
    public string Language3Qualifier { get; set; } = null!;
    */
    [XmlAttribute(AttributeName = "JAZ4")]
    public string Language4Code { get; set; } = null!;
    /*
    [XmlAttribute(AttributeName = "P_JAZ4")]
    public string Language4Qualifier { get; set; } = null!;
    */
    [XmlAttribute(AttributeName = "JAZYK_PR1")]
    public string InLanguage1Code { get; set; } = null!;

    [XmlAttribute(AttributeName = "POCET_PR1")]
    public string InLanguage1Count { get; set; } = null!;

    [XmlAttribute(AttributeName = "POCET_H2")]
    public string InLanguage1Hours { get; set; } = null!;

    [XmlAttribute(AttributeName = "JAZYK_PR2")]
    public string InLanguage2Code { get; set; } = null!;

    [XmlAttribute(AttributeName = "POCET_PR2")]
    public string InLanguage2Count { get; set; } = null!;

    [XmlAttribute(AttributeName = "POCET_H2")]
    public string InLanguage2Hours { get; set; } = null!;

    [XmlAttribute(AttributeName = "ZMENDAT")]
    public string ChangesAt { get; set; } = null!;

    [XmlAttribute(AttributeName = "KOD_ZMEN")]
    public string ChangesCode { get; set; } = null!;

    [XmlAttribute(AttributeName = "KOD_VETY")]
    public string SentenceCode { get; set; } = null!;

    [XmlAttribute(AttributeName = "PLAT_ZAC")]
    public string ValidityFrom { get; set; } = null!;

    [XmlAttribute(AttributeName = "PLAT_KON")]
    public string ValidityTo { get; set; } = null!;

    #region ZKOUSKA
    /*
     * KOD_ZK
     * KOD_OPAK
     * KOD_OP_M
     * KOD_OP_A
     * JAZABS
     * JAZM
     * VYSLCELK
     * VYSLCEL_M
     * VYSLCEL_A
     * ZKDAT
     * ZKDAT_M
     * ZKDAT_A
     * SERIE_V
     * CTISK_V
     * SERIE_L
     * CTISK_L
     * SERIE_A
     * CTISK_A
     * SERIE_D
     * CTISK_D
     * */
    #endregion
}

public static class SentenceExtensions
{
    public static Sentence ToSentence(this IAppMapper mapper, PersonDetail source)
    {
        _ = mapper.Now;
        var dest = new Sentence
        {
            BirthDate = source.BornOn?.ToString() ?? string.Empty,
            BirthNumber = source.IdentificationCode ?? string.Empty,
            ChangesAt = string.Empty,
            ChangesCode = string.Empty,
            Citizenship = source.Citizenship ?? string.Empty,
            CitizenshtipQualifier = source.CitizenshipCode ?? string.Empty,
            Class = string.Empty,//source.
            DecisiveCollectionDate = string.Empty, // ??????
            District = source.PermanentAddress?.CityDistrict ?? string.Empty,
           /* EducationEnd = source.Student!.EndsAt.ToString() ?? string.Empty,
            EducationEndCode = source.Student.EndReasonTypeId.ToString() ?? string.Empty,
            EducationLength = source.Student.StudyField.LengthInYears.ToString(),
            EducationStart = source.Student!.StartsAt.ToString(),
            EducationStartCode = source.Student.StartReasonTypeId.ToString() ?? string.Empty,
            EducationType = ((int)source.Student.StudyField.Type).ToString(),
            EducationQualifier = source.Student.StudyField.Qualifier,
            Financing = source.Student.Financing.ToString(),
            Form = source.Student.StudyField.Form.ToString(),*/
            Grade = string.Empty,
           // HighestAchievedEducation = ((int)source.Student.HighestAchievedEducation).ToString(),
            InLanguage1Code = string.Empty,
            InLanguage1Count = string.Empty,
            InLanguage1Hours = string.Empty,
            InLanguage2Code = string.Empty,
            InLanguage2Count = string.Empty,
            InLanguage2Hours = string.Empty,
            Interuption = string.Empty,
            Izo = source.Operation.IdentificationCode ?? string.Empty,
            LanguageStudy = string.Empty,
            Language1Code = string.Empty,
            Language2Code = string.Empty,
            Language3Code = string.Empty,
            Language4Code = string.Empty,
          //  MandatoryYears = source.Student.ObligatoryAttendenceYears.ToString(),
            Municipality = source.PermanentAddress?.City ?? string.Empty,
            OperationPart =  source.Operation.PartNumberForRegister ?? string.Empty,
          //  PreviousEducation = source.Student.PreviousEducationOperation.SchoolType.ToString(),
           // PreviousEducationIzo = source.Student.PreviousEducationOperation.IdentificationCode,
            SchoolGradeType = ((int)source.Operation.SchoolType).ToString(),
            SentenceCode = string.Empty, // ?????????????
            Sex = source.Sex?.ToString() ?? string.Empty,
           // StudyField = ((int)source.Student.StudyField.Type).ToString(),
            ValidityFrom = string.Empty, // ?????????????
            ValidityTo = string.Empty, // ?????????????
        };

        return dest;
    }
}
