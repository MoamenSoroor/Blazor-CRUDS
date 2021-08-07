using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Data
{
    public class Generator
    {

        public readonly Random Rand = new Random(Environment.TickCount);


        private static List<string> names = new List<string>()
        {"Layla","Moamen","Aaliyah","Xavier","Lyla","Amir","Kayl","Lail","Leil"
            ,"Lila","Zara","Omar","Nyla","Lila","Khalil","Ali ","Amin","Fatima",
            "Muhamma","Zayn","Nasi","Mali","Nyla","Ibrahim","Mohamed","Zariah",
            "Iman","Maryam","Aish","Alea","Yusu","Alia","Raya","Mariam","Zahr","Ahme",
            "Ahma","Amirah","Jami","Romina","Hamz","Mohamme","Kareem","Sami","Aman","Abdulla"
            ,"Zariyah","Hassan","Zari","Yara","Zora","Musa","Kamilah","Yahi","Zayd","Yaritza",
            "Khalid","Kaylie","Idri","Jama","Amee","Aliy","Zavier","Zainab","Salm","Noor","Zahi",
            "Yasmin","Eman","Samira","Mustafa"
        };

        private static List<string> tracksNames = new List<string>()
        {
       "Business", "Management", "Accounting", "Marketing", "Project Management",
            "Finance", "Administration", "Hotel Management",  "Leadership", "Management Training",
             "Risk Management",  "Supply Chain Management",  "Executive", "Leadership ",
             "Business Management", "Financial Management",  "Business Development",  "Corporatetraining",

        };



        public List<Trainee> GenerateTrainees(int count = 5)
        {

            List<Trainee> tracks = new List<Trainee>();

            tracks.AddRange(Enumerable.Range(0, count < 5 ? 5 : count).Select((x, i) =>
            {
                return new Trainee()
                {
                    //ID = x,
                    Name = names[i],
                    email = $"{names[i]}@gmail.com",
                    Birthdate = new DateTime(Rand.Next(1700, 2018), Rand.Next(1, 13), Rand.Next(1, 29)),
                    Gender = (Rand.Next(0, 2) == 0) ? Gender.Male : Gender.Female,
                    IsGraduated = (Rand.Next(0, 2) == 0),
                    MobileNo = string.Concat(Enumerable.Range(0, 12).ToList()),
                };
            }));

            return tracks;


        }

        public List<Track> GenerateTracks(int count = 5)
        {

            List<Track> tracks = new List<Track>();



            tracks.AddRange(Enumerable.Range(0, count < 5 ? 5 : count).Select((x, i) =>
            {
                return new Track()
                {
                    //ID = x,
                    Name = tracksNames[i],
                    Description = $"The {tracksNames[i]} is the best ever Course."
                };
            }));

            return tracks;


        }


        List<Trainee> trainees;
        List<Track> tracks;

        public List<Trainee> Trainees { get => trainees; }
        public List<Track> Tracks { get => tracks; }

        bool isInit = false;

        public void InitModels(int countTrainees, int countTracks)
        {
            if (!isInit)
            {
                trainees = GenerateTrainees(countTrainees);
                tracks = GenerateTracks(countTracks);

                trainees.ForEach(t =>
                {
                    t.Track = tracks[Rand.Next(0, tracks.Count)];
                });

                //tracks.ForEach(track =>
                //    trainees.Where(t => t.Track.ID == track.ID)
                //        .ToList().ForEach(tr => track.Trainees.Add(tr)));


                isInit = true;
            }

        }

    }
}
