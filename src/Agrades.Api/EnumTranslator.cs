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

    public static Rast GetRast(this IAppMapper mapper, string value) => (value) switch
    {
        "Zatím nezjištěno" => Rast.NotYetDetected,
        "Afghánská islámská republika" => Rast.IslamicRepublicOfAfghanistan,
        "Albánská republika" => Rast.RepublicOfAlbania,
        "Antarktida" => Rast.Antarctica,
        "Alžírská demokratická a lidová republika" => Rast.DemocraticAndPeoplesRepublicOfAlgeria,
        "Území Americká Samoa" => Rast.TerritoryOfAmericanSamoa,
        "Andorrské knížectví" => Rast.PrincipalityOfAndorra,
        "Angolská republika" => Rast.RepublicOfAngola,
        "Antigua a Barbuda" => Rast.AntiguaAndBarbuda,
        "Ázerbájdžánská republika" => Rast.RepublicOfAzerbaijan,
        "Argentinská republika" => Rast.ArgentineRepublic,
        "Australské společenství" => Rast.CommonwealthOfAustralia,
        "Rakouská republika" => Rast.RepublicOfAustria,
        "Bahamské společenství" => Rast.CommonwealthOfTheBahamas,
        "Království Bahrajn" => Rast.KingdomOfBahrain,
        "Bangladéšská lidová republika" => Rast.PeoplesRepublicOfBangladesh,
        "Arménská republika" => Rast.RepublicOfArmenia,
        "Barbados" => Rast.Barbados,
        "Belgické království" => Rast.KingdomOfBelgium,
        "Bermudy" => Rast.Bermuda,
        "Bhútánské království" => Rast.KingdomOfBhutan,
        "Mnohonárodní stát Bolívie" => Rast.MultinationalStateOfBolivia,
        "Bosna a Hercegovina" => Rast.BosniaAndHerzegovina,
        "Botswanská republika" => Rast.RepublicOfBotswana,
        "Bouvetův ostrov" => Rast.BouvetIsland,
        "Brazilská federativní republika" => Rast.FederativeRepublicOfBrazil,
        "Belize" => Rast.Belize,
        "Britské území v Indickém oceánu" => Rast.BritishIndianOceanTerritory,
        "Šalomounovy ostrovy" => Rast.SolomonIslands,
        "Britské Panenské ostrovy" => Rast.BritishVirginIslands,
        "Kosovská republika" => Rast.RepublicOfKosovo,
        "Stát Brunej Darussalam" => Rast.StateOfBruneiDarussalam,
        "Bulharská republika" => Rast.RepublicOfBulgaria,
        "Republika Myanmarský svaz" => Rast.RepublicOfTheUnionOfMyanmar,
        "Burundská republika" => Rast.RepublicOfBurundi,
        "Běloruská republika" => Rast.RepublicOfBelarus,
        "Kambodžské království" => Rast.KingdomOfCambodia,
        "Kamerunská republika" => Rast.RepublicOfCameroon,
        "Kanada" => Rast.Canada,
        "Kapverdská republika" => Rast.RepublicOfCapeVerde,
        "Kajmanské ostrovy" => Rast.CaymanIslands,
        "Středoafrická republika" => Rast.CentralAfricanRepublic,
        "Šrílanská demokratická socialistická republika" => Rast.DemocraticSocialistRepublicOfSriLanka,
        "Čadská republika" => Rast.RepublicOfChad,
        "Chilská republika" => Rast.RepublicOfChile,
        "Čínská lidová republika" => Rast.PeoplesRepublicOfChina,
        "Tchaj-wan" => Rast.Taiwan,
        "Území Vánoční ostrov" => Rast.ChristmasIslandTerritory,
        "Území Kokosové (Keelingovy) ostrovy" => Rast.TerritoryOfTheCocosIslands,
        "Kolumbijská republika" => Rast.RepublicOfColombia,
        "Komorský svaz" => Rast.UnionOfTheComoros,
        "Departement Mayotte" => Rast.DepartmentOfMayotte,
        "Konžská republika" => Rast.RepublicOfTheCongo,
        "Konžská demokratická republika" => Rast.DemocraticRepublicOfTheCongo,
        "Cookovy ostrovy" => Rast.CooksIslands,
        "Kostarická republika" => Rast.RepublicOfCostaRica,
        "Chorvatská republika" => Rast.RepublicOfCroatia,
        "Kubánská republika" => Rast.RepublicOfCuba,
        "Kyperská republika" => Rast.RepublicOfCyprus,
        "Česká republika" => Rast.CzechRepublic,
        "Beninská republika" => Rast.RepublicOfBenin,
        "Dánské království" => Rast.KingdomOfDenmark,
        "Dominické společenství" => Rast.DominicanCommunity,
        "Dominikánská republika" => Rast.DominicanRepublic,
        "Ekvádorská republika" => Rast.RepublicOfEcuador,
        "Salvadorská republika" => Rast.RepublicOfElSalvador,
        "Republika Rovníková Guinea" => Rast.RepublicOfEquatorialGuinea,
        "Etiopská federativní demokratická republika" => Rast.FederalDemocraticRepublicOfEthiopia,
        "Stát Eritrea" => Rast.StateOfEritrea,
        "Estonská republika" => Rast.RepublicOfEstonia,
        "Faerské ostrovy" => Rast.FaroeIslands,
        "Falklandy (Malvíny)" => Rast.Falklands,
        "Jižní Georgie a Jižní Sandwichovy ostrovy" => Rast.SouthGeorgiaAndTheSouthSandwichIslands,
        "Fidžijská republika" => Rast.RepublicOfFiji,
        "Finská republika" => Rast.RepublicOfFinland,
        "Provincie Alandy" => Rast.ProvinceOfÅland,
        "Francouzská republika" => Rast.TheFrenchRepublic,
        "Francouzská Guyana" => Rast.FrenchGuiana,
        "Francouzská Polynésie" => Rast.FrenchPolynesia,
        "Francouzská jižní a antarktická území" => Rast.FrenchSouthernAndAntarcticTerritories,
        "Džibutská republika" => Rast.RepublicOfDjibouti,
        "Gabonská republika" => Rast.RepublicOfGabon,
        "Gruzie" => Rast.Georgia,
        "Gambijská republika" => Rast.RepublicOfTheGambia,
        "Palestinská autonomní území" => Rast.PalestinianAutonomousTerritories,
        "Spolková republika Německo" => Rast.TheFederalRepublicOfGermany,
        "Ghanská republika" => Rast.RepublicOfGhana,
        "Gibraltar" => Rast.Gibraltar,
        "Republika Kiribati" => Rast.RepublicOfKiribati,
        "Řecká republika" => Rast.HellenicRepublic,
        "Grónsko" => Rast.Greenland,
        "Grenada" => Rast.Grenada,
        "Region Guadeloupe" => Rast.GuadeloupeRegion,
        "Teritorium Guam" => Rast.TerritoryOfGuam,
        "Guatemalská republika" => Rast.RepublicOfGuatemala,
        "Guinejská republika" => Rast.RepublicOfGuinea,
        "Guyanská kooperativní republika" => Rast.CooperativeRepublicOfGuyana,
        "Republika Haiti" => Rast.RepublicOfHaiti,
        "Heardův ostrov a MacDonaldovy ostrovy" => Rast.HeardIslandAndMacDonaldIslands,
        "Vatikánský městský stát" => Rast.VaticanCityState,
        "Honduraská republika" => Rast.RepublicOfHonduras,
        "Zvláštní administrativní oblast Čínské lidové republiky Hongkong" => Rast.HongKongSpecialAdministrativeRegionOfThePeoplesRepublicOfChina,
        "Maďarsko" => Rast.Hungary,
        "Islandská republika" => Rast.RepublicOfIceland,
        "Indická republika" => Rast.RepublicOfIndia,
        "Indonéská republika" => Rast.RepublicOfIndonesia,
        "Íránská islámská republika" => Rast.IslamicRepublicOfIran,
        "Irácká republika" => Rast.RepublicOfIraq,
        "Irsko" => Rast.Ireland,
        "Stát Izrael" => Rast.StateOfIsrael,
        "Italská republika" => Rast.ItalianRepublic,
        "Republika Pobřeží slonoviny" => Rast.RepublicOfIvoryCoast,
        "Jamajka" => Rast.Jamaica,
        "Japonsko" => Rast.Japan,
        "Republika Kazachstán" => Rast.RepublicOfKazakhstan,
        "Jordánské hášimovské království" => Rast.HashemiteKingdomOfJordan,
        "Keňská republika" => Rast.RepublicOfKenya,
        "Korejská lidově demokratická republika" => Rast.DemocraticPeoplesRepublicOfKorea,
        "Korejská republika" => Rast.TheKoreanRepublic,
        "Kuvajtský stát" => Rast.StateOfKuwait,
        "Kyrgyzská republika" => Rast.KyrgyzRepublic,
        "Laoská lidově demokratická republika" => Rast.LaoPeoplesDemocraticRepublic,
        "Libanonská republika" => Rast.RepublicOfLebanon,
        "Lesothské království" => Rast.KingdomOfLesotho,
        "Lotyšská republika" => Rast.RepublicOfLatvia,
        "Liberijská republika" => Rast.RepublicOfLiberia,
        "Libyjský stát" => Rast.LibyanState,
        "Lichtenštejnské knížectví" => Rast.PrincipalityOfLiechtenstein,
        "Litevská republika" => Rast.RepublicOfLithuania,
        "Lucemburské velkovévodství" => Rast.GrandDuchyOfLuxembourg,
        "Zvláštní administrativní oblast Čínské lidové republiky Macao" => Rast.MacaoSpecialAdministrativeRegionOfThePeoplesRepublicOfChina,
        "Madagaskarská republika" => Rast.RepublicOfMadagascar,
        "Malawiská republika" => Rast.RepublicOfMalawi,
        "Malajsie" => Rast.Malaysia,
        "Maledivská republika" => Rast.RepublicOfMaldives,
        "Republika Mali" => Rast.RepublicOfMali,
        "Maltská republika" => Rast.RepublicOfMalta,
        "Martinik" => Rast.Martinique,
        "Mauritánská islámská republika" => Rast.IslamicRepublicOfMauritania,
        "Mauricijská republika" => Rast.RepublicOfMauritius,
        "Spojené státy mexické" => Rast.UnitedMexicanStates,
        "Monacké knížectví" => Rast.PrincipalityOfMonaco,
        "Mongolsko" => Rast.Mongolia,
        "Moldavská republika" => Rast.RepublicOfMoldova,
        "Černá Hora" => Rast.Montenegro,
        "Montserrat" => Rast.Montserrat,
        "Marocké království" => Rast.KingdomOfMorocco,
        "Mosambická republika" => Rast.RepublicOfMozambique,
        "Sultanát Omán" => Rast.SultanateOfOman,
        "Namibijská republika" => Rast.RepublicOfNamibia,
        "Republika Nauru" => Rast.RepublicOfNauru,
        "Nepálská federativní demokratická republika" => Rast.FederalDemocraticRepublicOfNepal,
        "Nizozemsko" => Rast.Netherlands,
        "Země Curaçao" => Rast.TheCountryOfCuraçao,
        "Aruba" => Rast.Aruba,
        "Svatý Martin (NL)" => Rast.SaintMartin,
        " Saint Eustatius and Saba" => Rast.Bonaire,
        "Nová Kaledonie" => Rast.NewCaledonia,
        "Republika Vanuatu" => Rast.RepublicOfVanuatu,
        "Nový Zéland" => Rast.NewZealand,
        "Nikaragujská republika" => Rast.RepublicOfNicaragua,
        "Nigerská republika" => Rast.NigerRepublic,
        "Nigerijská federativní republika" => Rast.FederalRepublicOfNigeria,
        "Niue" => Rast.Niue,
        "Území Norfolk" => Rast.NorfolkTerritory,
        "Norské království" => Rast.KingdomOfNorway,
        "Společenství Severní Mariany" => Rast.CommunityOfTheNorthernMarianaIslands,
        "Menší odlehlé ostrovy USA" => Rast.SmallerOutlyingIslandsOfTheUSA,
        "Federativní státy Mikronésie" => Rast.FederatedStatesOfMicronesia,
        "Republika Marshallovy ostrovy" => Rast.RepublicOfTheMarshallIslands,
        "Republika Palau" => Rast.RepublicOfPalau,
        "Pákistánská islámská republika" => Rast.IslamicRepublicOfPakistan,
        "Panamská republika" => Rast.RepublicOfPanama,
        "Nezávislý stát Papua Nová Guinea" => Rast.TheIndependentStateOfPapuaNewGuinea,
        "Paraguayská republika" => Rast.RepublicOfParaguay,
        "Peruánská republika" => Rast.RepublicOfPeru,
        "Filipínská republika" => Rast.RepublicOfThePhilippines,
        "Pitcairnovy ostrovy" => Rast.PitcairnIslands,
        "Polská republika" => Rast.PolishRepublic,
        "Portugalská republika" => Rast.PortugueseRepublic,
        "Republika Guinea-Bissau" => Rast.RepublicOfGuineaBissau,
        "Demokratická republika Východní Timor" => Rast.DemocraticRepublicOfEastTimor,
        "Portorické společenství" => Rast.CommonwealthOfPuertoRico,
        "Stát Katar" => Rast.StateOfQatar,
        "Region Réunion" => Rast.RéunionRegion,
        "Rumunsko" => Rast.Romania,
        "Ruská federace" => Rast.RussianFederation,
        "Rwandská republika" => Rast.RepublicOfRwanda,
        "Společenství Svatý Bartoloměj" => Rast.CommunityOfSaintBartholomew,
        " Ascension and Tristan da Cunha" => Rast.SaintHelena,
        "Federace Svatý Kryštof a Nevis" => Rast.FederationOfSaintKittsAndNevis,
        "Anguilla" => Rast.Anguilla,
        "Svatá Lucie" => Rast.SaintLucia,
        "Společenství Svatý Martin" => Rast.SaintMartinCommunity,
        "Územní společenství Saint Pierre a Miquelon" => Rast.TerritorialCommunityOfSaintPierreAndMiquelon,
        "Svatý Vincenc a Grenadiny" => Rast.SaintVincentAndTheGrenadines,
        "Republika San Marino" => Rast.RepublicOfSanMarino,
        "Demokratická republika Svatý Tomáš a Princův ostrov" => Rast.DemocraticRepublicOfSãoToméAndPríncipe,
        "Království Saúdská Arábie" => Rast.KingdomOfSaudiArabia,
        "Senegalská republika" => Rast.RepublicOfSenegal,
        "Srbská republika" => Rast.RepublicOfSerbia,
        "Seychelská republika" => Rast.RepublicOfSeychelles,
        "Republika Sierra Leone" => Rast.RepublicOfSierraLeone,
        "Singapurská republika" => Rast.RepublicOfSingapore,
        "Slovenská republika" => Rast.SlovakRepublic,
        "Vietnamská socialistická republika" => Rast.SocialistRepublicOfVietnam,
        "Slovinská republika" => Rast.RepublicOfSlovenia,
        "Somálská federativní republika" => Rast.FederalRepublicOfSomalia,
        "Jihoafrická republika" => Rast.SouthAfricanRepublic,
        "Zimbabwská republika" => Rast.RepublicOfZimbabwe,
        "Španělské království" => Rast.KingdomOfSpain,
        "Jihosúdánská republika" => Rast.RepublicOfSouthSudan,
        "Súdánská republika" => Rast.RepublicOfSudan,
        "Saharská arabská demokratická republika" => Rast.SahrawiArabDemocraticRepublic,
        "Surinamská republika" => Rast.RepublicOfSuriname,
        "Špicberky a Jan Mayen" => Rast.SvalbardAndJanMayen,
        "Svazijské království" => Rast.KingdomOfSwaziland,
        "Švédské království" => Rast.KingdomOfSweden,
        "Švýcarská konfederace" => Rast.TheSwissConfederation,
        "Syrská arabská republika" => Rast.SyrianArabRepublic,
        "Republika Tádžikistán" => Rast.RepublicOfTajikistan,
        "Thajské království" => Rast.KingdomOfThailand,
        "Tožská republika" => Rast.RepublicOfTogo,
        "Tokelau" => Rast.Tokelau,
        "Království Tonga" => Rast.KingdomOfTonga,
        "Republika Trinidad a Tobago" => Rast.RepublicOfTrinidadAndTobago,
        "Stát Spojené arabské emiráty" => Rast.TheStateOfTheUnitedArabEmirates,
        "Tuniská republika" => Rast.RepublicOfTunisia,
        "Turecká republika" => Rast.RepublicOfTurkey,
        "Turkmenistán" => Rast.Turkmenistan,
        "Ostrovy Turks a Caicos" => Rast.TurksAndCaicosIslands,
        "Tuvalu" => Rast.Tuvalu,
        "Ugandská republika" => Rast.RepublicOfUganda,
        "Ukrajina" => Rast.Ukraine,
        "Republika Severní Makedonie" => Rast.RepublicOfNorthMacedonia,
        "Egyptská arabská republika" => Rast.ArabRepublicOfEgypt,
        "Spojené království Velké Británie a Severního Irska" => Rast.UnitedKingdomOfGreatBritainAndNorthernIreland,
        "Bailiwick Guernsey" => Rast.BailiwickOfGuernsey,
        "Bailiwick Jersey" => Rast.BailiwickOfJersey,
        "Ostrov Man" => Rast.IsleOfMan,
        "Tanzanská sjednocená republika" => Rast.UnitedRepublicOfTanzania,
        "Spojené státy americké" => Rast.UnitedStatesOfAmerica,
        "Americké Panenské ostrovy" => Rast.USVirginIslands,
        "Burkina Faso" => Rast.BurkinaFaso,
        "Uruguayská východní republika" => Rast.EasternRepublicOfUruguay,
        "Republika Uzbekistán" => Rast.RepublicOfUzbekistan,
        "Bolívarovská republika Venezuela" => Rast.BolivarianRepublicOfVenezuela,
        "Teritorium Wallisovy ostrovy a Futuna" => Rast.TerritoryOfTheWallisIslandsAndFutuna,
        "Nezávislý stát Samoa" => Rast.TheIndependentStateOfSamoa,
        "Jemenská republika" => Rast.RepublicOfYemen,
        "Zambijská republika" => Rast.RepublicOfZambia,
        "Ostatní" => Rast.Other,
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
