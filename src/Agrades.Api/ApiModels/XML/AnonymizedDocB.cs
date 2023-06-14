using Agrades.Api.Mapper;
using Agrades.Data.Entities;
using Agrades.Data.Entities.Categories;
using Agrades.Data.Entities.Classes;
using Agrades.Data.Entities.Persons;
using NodaTime;
using System.Globalization;
using System.Xml.Serialization;

namespace Agrades.Api.ApiModels.XML
{
    public class AnonymizedDocB
    {
        [XmlElement(ElementName = "RDAT")]
        public string DecisiveCollectionDate { get; set; } = null!;

        [XmlElement(ElementName = "IZO")]
        public string Izo { get; set; } = null!;

        [XmlElement(ElementName = "CAST")]
        public string OperationPart { get; set; } = null!;

        [XmlElement(ElementName = "OBOR")]
        public string FieldOfStudy { get; set; } = null!;

        [XmlElement(ElementName = "KOD_ZMEN")]

        public string ChangesCode { get; set; } = null!;

        [XmlElement(ElementName = "ZMENDAT")]
        public string ChangesAt { get; set; } = null!;

        //PLAT_ZAC
        [XmlElement(ElementName = "PLAT_ZAC")]
        public string StartDate { get; set; } = null!;
        //PLAT_KON
        [XmlElement(ElementName = "PLAT_KON")]
        public string EndDate { get; set; } = null!;
        //KOD_ZAKA
        [XmlElement(ElementName = "KOD_ZAKA")]
        public string StudentCode { get; set; } = null!;

        //ID_ZNEV
        [XmlElement(ElementName = "ID_ZNEV")]
        public string DisabilityCode { get; set; } = null!;

        //PSPO
        [XmlElement(ElementName = "PSPO")]
        public string DegreeOfProvidedPeasures { get; set; } = null!;

        //RED_IZO
        [XmlElement(ElementName = "RED_IZO")]
        public string CouncellingRedIzo { get; set; } = null!;

        //TT
        [XmlElement(ElementName = "TT")]
        public string ClassType { get; set; } = null!;

        //IZO_SPZ
        [XmlElement(ElementName = "IZO_SPZ")]
        public string CouncelingCenterIZO { get; set; } = null!;

        //DAT_VYD
        [XmlElement(ElementName = "DAT_VYD")]
        public string DecisionValidSince { get; set; } = null!;

        //DAT_KPD
        [XmlElement(ElementName = "DAT_KPD")]
        public string? DecisionValidTo { get; set; } = null!;

        //KOD_NFN
        [XmlElement(ElementName = "KOD_NFN")]
        public string FinancialDemandsCode { get; set; } = null!;
        
        //FN  0/1
        [XmlElement(ElementName = "FN")]
        public string Financing { get; set; } = null!;

        //DAT_ZAH
        [XmlElement(ElementName = "DAT_ZAH")]
        public string RealStartDate { get; set; } = null!;
        //DAT_UKON
        [XmlElement(ElementName = "DAT_UKON")]
        public string RealEndDate { get; set; } = null!;
    }
    public static class AnonymizedDocBExtensions
    {
        public static AnonymizedDocB ToAnonymizedDocB(this IAppMapper mapper,
            Instant? untilDate,
            Support support,
            Operation operation,
            GroupClassType type
            )
        {
            return new AnonymizedDocB
            {
                DecisiveCollectionDate = untilDate != null ? DateTime.Parse(untilDate.ToString()!).ToString() : string.Empty,
                Izo = operation.IdentificationCode == null ? string.Empty : operation.IdentificationCode,
                OperationPart = operation.PartNumberForRegister != null ? operation.PartNumberForRegister! : string.Empty,
                FieldOfStudy = type.ClassTypeDesignation == null ? string.Empty : ((int)type.ClassTypeDesignation).ToString(),
                ChangesCode = string.Empty,
                ChangesAt = string.Empty,
                StartDate = support.StartDate == null ? string.Empty : ((LocalDate)support.StartDate).ToString("d", new DateTimeFormatInfo()),
                EndDate = support.EndDate == null ? string.Empty : ((LocalDate)support.EndDate).ToString("d", new DateTimeFormatInfo()),
                StudentCode = support.StudentCode,
                DisabilityCode = mapper.GetIdOfDisString(support.DisabilityCode),
                DegreeOfProvidedPeasures = ((int)support.ProvidedLevelOfAid).ToString(),
                CouncellingRedIzo = support.CouncellingRedIzo == null? string.Empty : support.CouncellingRedIzo,
                ClassType =((int)type.ClassTypeDesignation).ToString(),
                CouncelingCenterIZO = support.CouncelingCenterIZO == null ? string.Empty : support.CouncelingCenterIZO,
                DecisionValidSince = support.DecisionValidSince.ToString("d", new DateTimeFormatInfo()),
                DecisionValidTo = support.DecisionValidTo == null ? string.Empty : ((LocalDate)support.DecisionValidTo).ToString("d", new DateTimeFormatInfo()),
                FinancialDemandsCode = mapper.GetIdOfFinString(support.FinancialDemands),
                Financing = support.Financing == null ? string.Empty : ((int)support.Financing).ToString(),
                RealStartDate = support.RealStartDate == null ? string.Empty : ((LocalDate)support.RealStartDate).ToString("d", new DateTimeFormatInfo()),
                RealEndDate = support.RealEndDate == null ? string.Empty : ((LocalDate)support.RealEndDate).ToString("d", new DateTimeFormatInfo()),
            };
        }
    } 
}
