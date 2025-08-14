using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speed; // kph

        public Cycling(DateTime date, double minutes, double speed)
            : base(date, minutes)
        {
            _speed = speed;
        }

        public override double GetDistance() => (_speed * _minutes) / 60;
        public override double GetSpeed() => _speed;
        public override double GetPace() => _minutes / GetDistance();
    }
}

