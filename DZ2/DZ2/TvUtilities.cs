using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DZ2
{
    public class TvUtilities
    {
        public static Episode Parse(string epizoda)
        {
            //Problemi s učitavanjem doubleova, pa sam potražio riješenje na stackoverflow. Točku je gledalo kao separator za tisućice umjesto kao decimalni točku.
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone(); customCulture.NumberFormat.NumberDecimalSeparator = "."; System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Episode ep = new Episode();
            Description desc = new Description();
            string[] tokens = epizoda.Split(',');
            ep.ViewerCount = (Convert.ToInt32(tokens[0]));
            //tokens[1] = tokens[1].Replace('.', ',');
            ep.RatingSum = Double.Parse(tokens[1]);
            //tokens[2] = tokens[2].Replace('.', ',');
            ep.LargestRating = (Double.Parse(tokens[2]));
            desc.Number = Convert.ToInt32(tokens[3]);
            desc.Lenght = TimeSpan.Parse(tokens[4]);
            desc.Name = tokens[5];
            ep.Description = desc;
            return ep;
        }

        public static void Sort(Episode[] episodes)
        {
            Episode[] sorted = new Episode[10];
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