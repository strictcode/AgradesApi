using Agrades.Api.Mapper;
using Agrades.Data.Entities;
using Agrades.Data.Entities.Categories;
using Agrades.Data.Entities.Classes;
using Agrades.Data.Entities.Persons;
using NodaTime;
using System.Globalization;
using System.Xml.Serialization;

namespace Agrades.Api.ApiModels.XML;

[XmlType(TypeName = "veta")]
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
    public string Interuption { get; set; } = null!; // idk

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
    public string Language1Qualifier { get; set; } = null!;// jen zakl
    */
    [XmlElement(ElementName = "JAZ2")]
    public string Language2Code { get; set; } = null!;//35
    /*
    [XmlElement(ElementName = "P_JAZ2")]
    public string Language2Qualifier { get; set; } = null!; // jen zakl
    */
    [XmlElement(ElementName = "JAZ3")]
    public string Language3Code { get; set; } = null!;
    /*
    [XmlElement(ElementName = "P_JAZ3")]
    public string Language3Qualifier { get; set; } = null!;// jen zakl
    */
    [XmlElement(ElementName = "JAZ4")]
    public string Language4Code { get; set; } = null!;
    /*
    [XmlElement(ElementName = "P_JAZ4")]
    public string Language4Qualifier { get; set; } = null!;// jen zakl
    */
    [XmlElement(ElementName = "JAZYK_PR1")]
    public string InLanguage1Code { get; set; } = null!;// jen zakl

    [XmlElement(ElementName = "POCET_PR1")]
    public string InLanguage1Count { get; set; } = null!;// jen zakl

    [XmlElement(ElementName = "POCET_H1")]
    public string InLanguage1Hours { get; set; } = null!;// jen zakl

    [XmlElement(ElementName = "JAZYK_PR2")]
    public string InLanguage2Code { get; set; } = null!;// jen zakl

    [XmlElement(ElementName = "POCET_PR2")]
    public string InLanguage2Count { get; set; } = null!;// jen zakl

    [XmlElement(ElementName = "POCET_H2")]
    public string InLanguage2Hours { get; set; } = null!;// jen zakl

    [XmlElement(ElementName = "ZMENDAT")]
    public string ChangesAt { get; set; } = null!;

    [XmlElement(ElementName = "KOD_ZMEN")]
    public string ChangesCode { get; set; } = null!; //nemám odkud

    [XmlElement(ElementName = "KOD_VETY")]
    public string SentenceCode { get; set; } = null!; //student kód 1/4, student/absolvent

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

    public static Sentence ToSentence(this IAppMapper mapper,
        PersonDetail personDetail, StudentDetail studentDetail,
        StudyField studyField, Operation operation, Address address,
        VirtualOperation virtualOperation, ClassDetail classDetail
        , int grade, Instant? untilDate)
    {
        _ = mapper.Now;
        var dest = new Sentence
        {
            BirthDate = personDetail.BornOn != null
          ? personDetail.BornOn.Value.Month > LocalDate.FromYearMonthWeekAndDay(2022, 9, 5, IsoDayOfWeek.Friday).Month
          ? $"{personDetail.BornOn.Value.Year}bb"
          : $"{personDetail.BornOn.Value.Year}aa"
          : string.Empty,

            BirthNumber = personDetail.IdentificationCode != null ? personDetail.IdentificationCode! : string.Empty,
            ChangesAt = string.Empty,
            //get from student, nowhere to get it from right now
            ChangesCode = ((int)Rakz.WithoutChange).ToString(),
            //Citizenship = personDetail.Citizenship != null ? ((int)personDetail.Citizenship).ToString() : string.Empty,
            CitizenshtipQualifier = personDetail.CitizenshipCode != null ? ((int)personDetail.CitizenshipCode).ToString() : string.Empty,
            Class = classDetail.Name,
            DecisiveCollectionDate = untilDate == null ? string.Empty : DateTime.Parse(untilDate.ToString()!).ToString(),
            /*We will get this from state district in adress*/
            District = "500054",
            EducationEnd = studentDetail.EndsAt != null ? studentDetail.EndsAt.ToString()! : string.Empty,
            EducationEndCode = studentDetail.EndReasonCode != null ? studentDetail.EndReasonCode!.ToString() : string.Empty,//source.Student.EndReasonTypeId.ToString() ?? string.Empty,
            EducationLength = mapper.RadsFromEnumToCode(Rads.FourYear), //studyField.LengthInYears.ToString(),
            EducationStart = studentDetail.StartsAt.ToString("d", new DateTimeFormatInfo()),
            EducationStartCode = mapper.RazvFromEnumToCode(studentDetail.StartReasonCode),
            EducationType = mapper.RafsFromEnumToCode(studyField.Type),
            //opravit PRIZN_ST
            EducationQualifier = string.Empty,
            Financing = studentDetail.Financing != null ? studentDetail.Financing.ToString()! : string.Empty,
            //opravit ZPUSOB
            Form = ((int)studyField.Form).ToString(),
            Grade = grade.ToString(),
            HighestAchievedEducation = mapper.RakkFromEnumToCode(studentDetail.HighestAchievedEducation),

            //InLanguage1Code = string.Empty,
            //InLanguage1Count = string.Empty,
            //InLanguage1Hours = string.Empty,
            //InLanguage2Code = string.Empty,
            //InLanguage2Count = string.Empty,
            //InLanguage2Hours = string.Empty,
            Interuption = string.Empty,
            Izo = operation.IdentificationCode != null ? operation.IdentificationCode!.Replace(" ", "") : string.Empty,
            LanguageStudy = "10",
            Language1Code = "02",
            Language2Code = "25",
            Language3Code = string.Empty,
            Language4Code = string.Empty,
            MandatoryYears = studentDetail.ObligatoryAttendenceYears != null ? studentDetail.ObligatoryAttendenceYears.ToString()! : string.Empty,
            /*fix, just temporary solution to test other things */
            Municipality = "CZ0100",//address.City != null ? address.City : string.Empty,
            OperationPart = operation.PartNumberForRegister != null ? operation.PartNumberForRegister! : string.Empty,
            PreviousEducation = mapper.RapzFromEnumToCode(virtualOperation.SchoolType),
            PreviousEducationIzo = virtualOperation.IdentificationCode,
            SchoolGradeType =string.Empty,// ((int)operation.SchoolType).ToString(),
            //opravit KOD_VETY
            SentenceCode = string.Empty, // ?????????????
            Sex = personDetail.Sex != null ? ((int)personDetail.Sex).ToString() : string.Empty,
            //chyba, OBOR
            StudyField = ((int)studyField.Type).ToString(),
            ValidityFrom = studentDetail.ValidSince.ToString(), // ?????????????
            ValidityTo = studentDetail.ValidUntil != null ? studentDetail.ValidUntil.ToString()! : string.Empty, // ?????????????
        };

        return dest;
    }
}
