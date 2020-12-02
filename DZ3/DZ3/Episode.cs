using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DZ3
{
    public class Episode
    {
        private int viewerCount;
        private double ratingSum;
        private double largestRating;
        private Description description;
        public Episode()
        {
            viewerCount = 0;
            ratingSum = 0;
            largestRating = 0;
        }

        public Episode(int viewers, double sum, double largest, Description description)
        {
            this.viewerCount = viewers;
            this.ratingSum = Convert.ToDouble(sum);
            this.largestRating = Convert.ToDouble(largest);
            this.description = description;
        }

        public int ViewerCount { get => viewerCount; set => viewerCount = value; }
        public double RatingSum { get => ratingSum; set => ratingSum = value; }
        public double LargestRating { get => largestRating; set => largestRating = value; }
        public Description Description { get => description; set => description = value; }



        public void AddView(double rating)
        {
            viewerCount++;
            ratingSum += rating;
            if (rating > this.largestRating)
                this.largestRating = rating;
            largestRating = Math.Round(largestRating, 4);
            ratingSum = Math.Round(ratingSum, 4);
        }

        public double GenerateRandomScore()
        {
            Random generator = new Random();
            return generator.NextDouble() * 10;
        }

        public double GetMaxScore()
        {
            return largestRating;
        }

        public double GetAverageScore()
        {
            return ratingSum / viewerCount;
        }

        public int GetViewerCount()
        {
            return viewerCount;
        }

        public override String ToString()
        {
            return $"{viewerCount},{ratingSum},{largestRating},{description}";
        }

        public static bool operator<(Episode ep1, Episode ep2)
        {
            if (ep1.GetAverageScore() < ep2.GetAverageScore())
                return true;
            else return false;
        }
        public static bool operator >(Episode ep1, Episode ep2)
        {
            if (ep1.GetAverageScore() > ep2.GetAverageScore())
                return true;
            else return false;
        }
    }
}
