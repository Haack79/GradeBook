using System;

namespace GradeBook
{
    public class Statistics
    {
        //Create variables
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                        
                    case var d when d >= 80.0:
                        return 'B';
                        
                    case var d when d >= 70.0:
                        return 'C';
                        
                    case var d when d >= 60.0:
                        return 'D';
                        
                    default:
                        return 'F';
                        
                }
            }
        }
        public double Sum;
        public int Count;
        // Method to count
        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
        // Constructor 
        public Statistics()
        {
            // Average = 0.0; this is now read only, cant be set but will be computed above. 
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }
}