using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DZ4
{
    public class Season : IEnumerable<Episode>
    {
        public int number { get; private set; }
        private List<Episode> episodes;
        public Season(int number, List<Episode> episodes)
        {
            this.number = number;
            this.episodes = episodes;
        }
        public Season(Season other)
        {
            var newEpisodes = new List<Episode>();
            foreach(var episode in other.episodes)
                newEpisodes.Add(new Episode(episode.ViewerCount, episode.RatingSum, episode.LargestRating, episode.Description));
            this.number = other.number;
            this.episodes = newEpisodes;
        }
        public void Add(Episode episode)
        {
            episodes.Add(episode);
        }
        public void Remove(string Title)
        {
            if (episodes.RemoveAll(ep => ep.Description.Name == Title) != 1)
                throw new TvException("No such episode found.",Title);
        }
        public override string ToString()
        {
            int totalViewers = 0;
            TimeSpan totalDuration = new TimeSpan(0, 0, 0);
            string output = null;
            output += $"Season {number}:\n";
            output += "=================================================\n";

            for (int i = 0; i < episodes.Count; i++)
            {
                output += Convert.ToString(episodes[i] + Environment.NewLine);
                totalViewers += episodes[i].ViewerCount;
                totalDuration += episodes[i].Description.Lenght;
            }
            output += "Report:\n";
            output += "=================================================\n";
            output += $"Total viewers: {totalViewers}\n";
            output += $"Total duration: {totalDuration}\n";
            output += "=================================================\n";
            return output;
        }

        public Episode this[int i]
        {
            get { return episodes[i]; }
        }

        public int Length => episodes.Count;
        public IEnumerator<Episode> GetEnumerator()
        {
            return episodes.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
