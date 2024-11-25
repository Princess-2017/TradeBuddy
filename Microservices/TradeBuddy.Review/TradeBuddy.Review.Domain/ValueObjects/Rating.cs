using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Review.Domain.ValueObjects
{
    public class Rating
    {
        public int Value { get; private set; }

        public Rating(int value)
        {
            if (value < 1 || value > 5)
                throw new ArgumentException("Rating must be between 1 and 5.");

            Value = value;
        }

        public Rating () { }

        public static implicit operator int(Rating rating) => rating.Value;
        public static implicit operator Rating(int value) => new Rating(value);
    }

}
