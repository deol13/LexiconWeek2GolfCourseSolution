using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconWeek2GolfCourse
{
    public class Swing
    {
        private double angle;
        private double velocity;

        public Swing()
        {
            angle = 0;
            velocity = 0;
        }

        public Swing(double inAangle, double inVelocity)
        {
            angle = inAangle;
            velocity = inVelocity;
        }

        public double Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public double Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public void resetSwing()
        {
            angle = 0;
            velocity = 0;
        }
    }
}
