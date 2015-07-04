using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mamorgen
{
    public class Magister
    {
		public struct School
		{
			public string Name { get; set; }
			public string Url { get; set; }
		}

		public static async Task<List<School>> GetSchools(string seearchFor)
		{
			return new List<School> () {
				new School () { Name = "Magister Test College", Url = "https://appcontest.zenacc.nl/" }
			};
		}

        /// <summary>
        /// Name of the school
        /// </summary>
        public string SchoolName
        {
            get;
            private set;
        }

        /// <summary>
        /// First name of the person
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Log in to the system
        /// </summary>
        /// <param name="User">The Username</param>
        /// <param name="Pass">The password</param>
        /// <returns></returns>
        public async Task<bool> Login(string School, string User, string Pass)
        {
            SchoolName = "Mock data";
            Name = "Jan";
            
            // mock stuff, in real life actually post /api/sessie, then get /api/account
            return true;
        }

        public struct MagisterAgendaVakInfo
        {
            public int Id;
            public string Naam;
        }

        public struct MagisterAgendaDocentInfo
        {   
            public int Id;
            public string Naam;
            public string Docentcode;
        }

        public struct MagisterAgendaLokaalInfo
        {
            public string Naam;
        }

        public enum AfspraakStatus
        {
            GeenStatus,
            GeroosterdAutomatisch,
            GeroosterdHandmatig,
            Gewijzigd,
            VervallenHandmatig,
            VervallenAutomatisch,
            InGebruik,
            Afgesloten,
            Ingezet,
            Verplaatst
        }

        public enum AfspraakType
        {
            None,
            Persoonlijk,
            Algemeen,
            Schoolbreed,
            Stage,
            Intake,
            Roostervrij,
            Kwt,
            Standby,
            Blokkade,
            Overig,
            BlokkadeLokaal,
            BlokkadeKlas,
            Les,
            Studiehuis,
            RoostervrijeStudie,
            Planning,
            Maatregelen,
            Presenties,
            ExamenRooster
        }

        public enum WeergaveType
        {
            Vrij = 1,
            VoorlopigBezet,
            Bezet,
            NietAanwezig
        }

        public enum AfspraakInfoType
        {
            None,
            Huiswerk,
            Proefwerk,
            Tentamen,
            SchriftelijkeOverhoring,
            MondelingeOverhoring,
            Informatie,
            Aantekening
        }

        public struct MagisterAgendaItem
        {
            public int Id;
            public DateTime Start;
            public DateTime Einde;
            public int LesuurVan;
            public int LesuurTotMet;
            public bool DuurtHeleDag;
            public string Omschrijving;
            public string Lokatie;
            public AfspraakStatus Status;
            public AfspraakType Type;
            public WeergaveType WeergaveType;
            public string Inhoud;
            public AfspraakInfoType InfoType;
            public string Aantekening;
            public bool Afgerond;
            public List<MagisterAgendaVakInfo> Vakken;
            public List<MagisterAgendaDocentInfo> Docenten;
            public List<MagisterAgendaLokaalInfo> Lokalen;
            public object Groepen;
            public int OpdrachtId;
            public bool HeeftBijlagen;
            public object Bijlagen;
        }

        public async Task<List<MagisterAgendaItem>> GetAgendaData(DateTime start, DateTime end)
        {
            List<MagisterAgendaItem> Items = new List<MagisterAgendaItem>();

            for (int i = 0; i < 8; i++)
            {
                Items.Add(new MagisterAgendaItem()
                {
                    Id = i,
                    Start = new DateTime(2015, 7, 3, i, 0, 0),
                    Einde = new DateTime(2015, 7, 3, i, 50, 0),
                    LesuurVan = i,
                    LesuurTotMet = i,
                    DuurtHeleDag = false,
                    Omschrijving = "" + i,
                    Lokatie = "Microsoft Nederland",
                    Status = AfspraakStatus.GeroosterdAutomatisch,
                    Type = AfspraakType.Les,
                    WeergaveType = WeergaveType.Bezet,
                    Inhoud = "Bacon",
                    InfoType = AfspraakInfoType.Informatie,
                    Aantekening = null,
                    Afgerond = false,
                    Vakken = new List<MagisterAgendaVakInfo>() { new MagisterAgendaVakInfo() { Id = 0, Naam = "Bacon eten" } },
                    Docenten = new List<MagisterAgendaDocentInfo>() { new MagisterAgendaDocentInfo() { Id = 0, Naam = "Baconator", Docentcode = "BCNTR"} },
                    Lokalen = new List<MagisterAgendaLokaalInfo>() { new MagisterAgendaLokaalInfo() { Naam = "091" } },
                    Groepen = null,
                    OpdrachtId = 0,
                    HeeftBijlagen = false,
                    Bijlagen = null
                });
            }

            return Items;
        }
    }
}
