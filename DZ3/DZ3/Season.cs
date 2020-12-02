using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DZ3
{
    public class Season
    {
        public int number { get; private set; }
        public Episode[] episodes { get; private set; }

        public Season(int number, Episode[] episodes)
        {
            this.number = number;
            this.episodes = episodes;
        }

        public override string ToString()
        {
            int totalViewers = 0;
            TimeSpan totalDuration = new TimeSpan(0,0,0);
            string output = null;
            output += $"Season {number}:\n";
            output += "=================================================\n";

            for (int i = 0; i < episodes.Length; i++)
            {
                output += Convert.ToString(episodes[i] + Environment.NewLine);
                totalViewers += episodes[i].ViewerCount;
                totalDuration += episodes[i].Description.Lenght;
            }
            output += "Report:\n";
            output += "=================================================\n";
            output += $"Total viewers: {totalViewers}\n";
            output += $"Total duration: {totalDuration}\n";
            return output;
        }

        public Episode this[int i]
        {
            get { return episodes[i]; }
        }

        public int Length => episodes.Length;

    }
}
