using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Models
{
    public static class StaticGenerator
    {

        public static readonly Random Rand = new Random(Environment.TickCount);


        public static List<string> names = new List<string>()
        {"Layla","Moamen","Aaliyah","Xavier","Lyla","Amir","Kayl","Lail","Leil"
            ,"Lila","Zara","Omar","Nyla","Lila","Khalil","Ali ","Amin","Fatima",
            "Muhamma","Zayn","Nasi","Mali","Nyla","Ibrahim","Mohamed","Zariah",
            "Iman","Maryam","Aish","Alea","Yusu","Alia","Raya","Mariam","Zahr","Ahme",
            "Ahma","Amirah","Jami","Romina","Hamz","Mohamme","Kareem","Sami","Aman","Abdulla"
            ,"Zariyah","Hassan","Zari","Yara","Zora","Musa","Kamilah","Yahi","Zayd","Yaritza",
            "Khalid","Kaylie","Idri","Jama","Amee","Aliy","Zavier","Zainab","Salm","Noor","Zahi",
            "Yasmin","Eman","Samira","Mustafa"
        };

        public static List<string> tracksNames = new List<string>()
        {
       "Business", "Management", "Accounting", "Marketing", "ProjectManagement",
            "Finance", "Administration", "Hotel Management",  "Leadership", "Management Training",
             "Risk Management",  "Supply Chain Management",  "Executive", "Leadership ",
             "Business Management", "Financial Management",  "Business Development",  "Corporatetraining",
            "Business Management"

        };


        public static List<Trainee> GenerateTrainees(int count = 5)
        {

            List<Trainee> tracks = new List<Trainee>();



            tracks.AddRange(Enumerable.Range(0, count < 5 ? 5 : count).Select((x, i) =>
            {
                return new Trainee()
                {
                    ID = x,
                    Name = names[Rand.Next(0, names.Count - 1)],
                    email = $"{names[Rand.Next(0, names.Count - 1)]}@gmail.com",
                    Birthdate = new DateTime(Rand.Next(1700,2018), Rand.Next(1, 13), Rand.Next(1, 29)),
                    Gender = (Rand.Next(0,2) == 0)? Gender.Male: Gender.Female,
                    IsGraduated = (Rand.Next(0, 2) == 0),
                    MobileNo = string.Concat(Enumerable.Range(0,12).ToList()),
                };
            }));

            return tracks;


        }

        public static List<Track> GenerateTracks(int count = 5)
        {

            List<Track> tracks = new List<Track>();



            tracks.AddRange(Enumerable.Range(0, count < 5 ? 5 : count).Select((x, i) =>
            {
                var name = tracksNames[Rand.Next(0, tracksNames.Count - 1)];
                return new Track()
                {
                    ID = x,
                    Name = name,
                    Description = $"The {name} is the best ever Course."
                };
            }));

            return tracks;


        }


        static List<Trainee> trainees;
        static List<Track> tracks;

        public static List<Trainee> Trainees { get => trainees; }
        public static List<Track> Tracks { get => tracks; }

        static bool isInit = false;

        public static void InitModels(int countTrainees, int countTracks)
        {
            if(!isInit)
            {
                trainees = GenerateTrainees(countTrainees);
                tracks = StaticGenerator.GenerateTracks(countTracks);

                trainees.ForEach(t => t.Track = tracks[StaticGenerator.Rand.Next(0, tracks.Count)]);

                isInit = true;
            }
            
        }

}
}
