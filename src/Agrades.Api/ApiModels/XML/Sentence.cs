using Agrades.Api.Mapper;
using Agrades.Data.Entities;
using Agrades.Data.Entities.Persons;
using System.Xml.Serialization;

namespace Agrades.Api.ApiModels.XML;

public class Sentence
{
    /// <summary>
    /// 
    /// </summary>
    [XmlElement(ElementName = "RDAT")]
    public string DecisiveCollectionDate { get; set; } = null!;

    [XmlElement(ElementName = "IZO")]
    public string Izo { get; set; } = null!;

    [XmlElement(ElementName = "CAST")]
    public string OperationPart { get; set; } = null!;

    [XmlElement(ElementName = "RODC")]
    public string BirthNumber { get; set; } = null!;

    [XmlElement(ElementName = "POHLAVI")]
    public string Sex { get; set; } = null!;

    [XmlElement(ElementName = "DAT_NAROZ")]
    public string BirthDate { get; set; } = null!;

    [XmlElement(ElementName = "KSTPR")]
    public string CitizenshtipQualifier { get; set; } = null!;

    [XmlElement(ElementName = "STPR")]
    public string Citizenship { get; set; } = null!;

    /// <summary>
    /// Obec
    /// </summary>
    [XmlElement(ElementName = "OBECB")]
    public string Municipality { get; set; } = null!;

    [XmlElement(ElementName = "OKRESB")]
    public string District { get; set; } = null!;

    [XmlElement(ElementName = "ODHL")]
    public string PreviousEducation { get; set; } = null!;

    [XmlElement(ElementName = "IZOZ")]
    public string PreviousEducationIzo { get; set; } = null!;

    //[XmlElement(ElementName = "IZOS")]
    //public string PreviousLeavingExamIzo { get; set; } = null!;

    // ///<summary>
    // ///HVS - vyšší odborná škola
    // ///</summary>
    //[XmlElement(ElementName = "OBORS")]
    //public string HvsStudyFieldCode { get; set; } = null!;

    [XmlElement(ElementName = "STUPEN")]
    public string HighestAchievedEducation { get; set; } = null!;

    [XmlElement(ElementName = "ZAHDAT")]
    public string EducationStart { get; set; } = null!;

    [XmlElement(ElementName = "KOD_ZAH")]
    public string EducationStartCode { get; set; } = null!;

    [XmlElement(ElementName = "UKONDAT")]
    public string EducationEnd { get; set; } = null!;

    [XmlElement(ElementName = "KOD_UKON")]
    public string EducationEndCode { get; set; } = null!;

    [XmlElement(ElementName = "ROCNIK")]
    public string Grade { get; set; } = null!;

    [XmlElement(ElementName = "TRIDA")]
    public string Class { get; set; } = null!;

    [XmlElement(ElementName = "ST_SKOLY")]
    public string SchoolGradeType { get; set; } = null!;

    [XmlElement(ElementName = "ZPUSOB")]
    public string Form { get; set; } = null!;

    [XmlElement(ElementName = "PRIZN_ST")]
    public string EducationQualifier { get; set; } = null!;

    [XmlElement(ElementName = "PRERUS")]
    public string Interuption { get; set; } = null!;

    [XmlElement(ElementName = "FIN")]
    public string Financing { get; set; } = null!;

    [XmlElement(ElementName = "OBOR")]
    public string StudyField { get; set; } = null!;
    /*
    [XmlElement(ElementName = "OBOR2")]
    public string StudyField2 { get; set; } = null!;
    */
    [XmlElement(ElementName = "DELST")]
    public string EducationLength { get; set; } = null!;

    [XmlElement(ElementName = "FST")]
    public string EducationType { get; set; } = null!;

    [XmlElement(ElementName = "LET_PSD")]
    public string MandatoryYears { get; set; } = null!;

    [XmlElement(ElementName = "JAZYK_O")]
    public string LanguageStudy { get; set; } = null!;

    [XmlElement(ElementName = "JAZ1")]
    public string Language1Code { get; set; } = null!;
    /*
    [XmlElement(ElementName = "P_JAZ1")]
    public string Language1Qualifier { get; set; } = null!;
    */
    [XmlElement(ElementName = "JAZ2")]
    public string Language2Code { get; set; } = null!;
    /*
    [XmlElement(ElementName = "P_JAZ2")]
    public string Language2Qualifier { get; set; } = null!;
    */
    [XmlElement(ElementName = "JAZ3")]
    public string Language3Code { get; set; } = null!;
    /*
    [XmlElement(ElementName = "P_JAZ3")]
    public string Language3Qualifier { get; set; } = null!;
    */
    [XmlElement(ElementName = "JAZ4")]
    public string Language4Code { get; set; } = null!;
    /*
    [XmlElement(ElementName = "P_JAZ4")]
    public string Language4Qualifier { get; set; } = null!;
    */
    [XmlElement(ElementName = "JAZYK_PR1")]
    public string InLanguage1Code { get; set; } = null!;

    [XmlElement(ElementName = "POCET_PR1")]
    public string InLanguage1Count { get; set; } = null!;

    [XmlElement(ElementName = "POCET_H1")]
    public string InLanguage1Hours { get; set; } = null!;

    [XmlElement(ElementName = "JAZYK_PR2")]
    public string InLanguage2Code { get; set; } = null!;

    [XmlElement(ElementName = "POCET_PR2")]
    public string InLanguage2Count { get; set; } = null!;

    [XmlElement(ElementName = "POCET_H2")]
    public string InLanguage2Hours { get; set; } = null!;

    [XmlElement(ElementName = "ZMENDAT")]
    public string ChangesAt { get; set; } = null!;

    [XmlElement(ElementName = "KOD_ZMEN")]
    public string ChangesCode { get; set; } = null!;

    [XmlElement(ElementName = "KOD_VETY")]
    public string SentenceCode { get; set; } = null!;

    [XmlElement(ElementName = "PLAT_ZAC")]
    public string ValidityFrom { get; set; } = null!;

    [XmlElement(ElementName = "PLAT_KON")]
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
    public static Sentence ToSentence(this IAppMapper mapper, PersonDetail personDetail, Student student, StudentDetail studentDetail, StudyField studyField, Operation operation, Address address, VirtualOperation virtualOperation)
    {
        _ = mapper.Now;
        var dest = new Sentence
        {
            BirthDate = personDetail.BornOn != null ? personDetail.BornOn.ToString()! : string.Empty,
            BirthNumber = personDetail.IdentificationCode != null ? personDetail.IdentificationCode! : string.Empty,
            ChangesAt = string.Empty,
            ChangesCode = string.Empty,
            Citizenship = personDetail.Citizenship != null ? personDetail.Citizenship! : string.Empty,
            CitizenshtipQualifier = personDetail.CitizenshipCode != null ? personDetail.CitizenshipCode! : string.Empty,
            Class = string.Empty,//source.
            DecisiveCollectionDate = string.Empty, // ??????
            District = address.CityDistrict != null ? address.CityDistrict! : string.Empty,
            EducationEnd = studentDetail.EndsAt != null ? studentDetail.EndsAt.ToString()! : string.Empty,
            EducationEndCode = studentDetail.EndReasonCode != null ? studentDetail.EndReasonCode!.ToString() : string.Empty,//source.Student.EndReasonTypeId.ToString() ?? string.Empty,
            EducationLength = studyField.LengthInYears.ToString(),
            EducationStart = studentDetail.StartsAt.ToString(),
            EducationStartCode = studentDetail.StartReasonCode != null ? studentDetail.StartReasonCode.ToString()! : string.Empty,
            EducationType = ((int)studyField.Type).ToString(),
            EducationQualifier = studyField.Qualifier,
            Financing = studentDetail.Financing != null ? studentDetail.Financing.ToString()! : string.Empty,
            Form = studyField.Form.ToString(),
            Grade = string.Empty,
            HighestAchievedEducation = ((int)studentDetail.HighestAchievedEducation).ToString(),
            InLanguage1Code = string.Empty,
            InLanguage1Count = string.Empty,
            InLanguage1Hours = string.Empty,
            InLanguage2Code = string.Empty,
            InLanguage2Count = string.Empty,
            InLanguage2Hours = string.Empty,
            Interuption = string.Empty,
            Izo = operation.IdentificationCode != null ? operation.IdentificationCode! : string.Empty,
            LanguageStudy = string.Empty,
            Language1Code = string.Empty,
            Language2Code = string.Empty,
            Language3Code = string.Empty,

            Language4Code = string.Empty,
            MandatoryYears = studentDetail.ObligatoryAttendenceYears != null ? studentDetail.ObligatoryAttendenceYears.ToString()! : string.Empty,
            Municipality = address.City != null ? address.City : string.Empty,
            OperationPart = operation.PartNumberForRegister != null ? operation.PartNumberForRegister! : string.Empty,
            PreviousEducation = virtualOperation.SchoolType.ToString(),
            PreviousEducationIzo = virtualOperation.IdentificationCode,
            SchoolGradeType = ((int)operation.SchoolType).ToString(),
            SentenceCode = string.Empty, // ?????????????
            Sex = personDetail.Sex != null ? personDetail.Sex.ToString()! : string.Empty,
            StudyField = ((int)studyField.Type).ToString(),
            ValidityFrom = string.Empty, // ?????????????
            ValidityTo = string.Empty, // ?????????????
        };

        return dest;
    }
}
