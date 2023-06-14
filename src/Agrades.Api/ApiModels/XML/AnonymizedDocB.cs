using Agrades.Api.Mapper;
using Agrades.Data.Entities;
using Agrades.Data.Entities.Categories;
using Agrades.Data.Entities.Persons;
using NodaTime;
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
        public string FinancialDmeandsCode { get; set; } = null!;
        
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
            Operation operation
            )
        {
            var output = new AnonymizedDocB
            {
                DecisiveCollectionDate = string.Empty,
                Izo = operation.IdentificationCode == null ? string.Empty : operation.IdentificationCode,
                OperationPart = string.Empty,
                FieldOfStudy = string.Empty,
                ChangesCode = string.Empty,
                ChangesAt = string.Empty,
                StartDate = string.Empty,
                EndDate = string.Empty,
                StudentCode = support.StudentCode,
                DisabilityCode = mapper.GetIdOfDisString(support.DisabilityCode),
                DegreeOfProvidedPeasures = string.Empty,
                CouncellingRedIzo = support.CouncellingRedIzo == null? string.Empty : support.CouncellingRedIzo,
                ClassType = string.Empty,
                CouncelingCenterIZO = string.Empty,
                DecisionValidSince = string.Empty,
                DecisionValidTo = string.Empty,
                FinancialDmeandsCode =string.Empty,
                Financing = support.Financing == null ? string.Empty : ((int)support.Financing).ToString(),
                RealStartDate = string.Empty,
                RealEndDate = string.Empty,
            };

            


            return output;
        }
    }
}
