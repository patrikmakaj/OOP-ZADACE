using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace DZ4
{
    public class TvUtilities
    {
        public static double GenerateRandomScore()
        {
            Random gen = new Random();
            return gen.NextDouble() * 10;
        }
        public static Episode Parse(string epizoda)
        {
            //Problemi s učitavanjem doubleova, pa sam potražio riješenje na stackoverflow. Točku je gledalo kao separator za tisućice umjesto kao decimalni točku.
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone(); customCulture.NumberFormat.NumberDecimalSeparator = "."; System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Episode ep = new Episode();
            Description desc = new Description();
            string[] tokens = epizoda.Split(',');
            ep.ViewerCount = (Convert.ToInt32(tokens[0]));
            ep.RatingSum = Double.Parse(tokens[1]);
            ep.LargestRating = (Double.Parse(tokens[2]));
            desc.Number = Convert.ToInt32(tokens[3]);
            //desc.Lenght = TimeSpan.Parse(tokens[4]);
            desc.Lenght = TimeSpan.ParseExact(tokens[4], "%m", CultureInfo.InvariantCulture, TimeSpanStyles.None);
            desc.Name = tokens[5];
            ep.Description = desc;
            return ep;
        }
        public static List<Episode> LoadEpisodesFromFile(string fileName)
        {
            string[] episodesInputs = File.ReadAllLines(fileName);
            var episodes = new List<Episode>();
            for (int i = 0; i < episodesInputs.Length; i++)
                episodes.Add(TvUtilities.Parse(episodesInputs[i]));
            return episodes;
        }
        public static void Sort(Episode[] episodes)
        {
            Episode[] sorted = new Episode[episodes.Length];
            int i, j;
            for (i = 0; i < episodes.Length - 1; i++)
            {
                for (j = 0; j < episodes.Length - i - 1; j++)
                {
                    if (episodes[j] < episodes[j + 1])
                    {
                        Episode temp = new Episode();
                        temp = episodes[j];
                        episodes[j] = episodes[j + 1];
                        episodes[j + 1] = temp;
                    }
                }
            }
        }
    }
}