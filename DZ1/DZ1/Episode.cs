using System;

namespace DZ1
{
    public class Episode
    {
        private int viewerCount;
        private double ratingSum;
        private double largestRating;

        public Episode()
        {
            viewerCount = 0;
            ratingSum = 0;
            largestRating = 0;
        }

        public Episode(int viewers, double sum, double largest)
        {
            this.viewerCount = viewers;
            this.ratingSum = sum;
            this.largestRating = largest;
        }

        public void AddView(double rating)
        {
            viewerCount++;
            ratingSum += rating;
            if (rating > this.largestRating)
                this.largestRating = rating;
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

    }
}
