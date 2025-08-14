using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        protected DateTime _date;
        protected double _minutes;

        public Activity(DateTime date, double minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        public abstract double GetDistance(); // km
        public abstract double GetSpeed();    // kph
        public abstract double GetPace();     // min per km

        public virtual string GetSummary()
        {
            return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min) - " +
                   $"Distance: {GetDistance():0.0} km, " +
                   $"Speed: {GetSpeed():0.0} kph, " +
                   $"Pace: {GetPace():0.00} min per km";
        }
    }
}

