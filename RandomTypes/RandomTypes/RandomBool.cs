using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomTypes
{
    public class RandomBool : IRandomType<bool>
    {
        private readonly Random _random;

        public bool GetNext()
        {
            return _random.Next(0, 9) > 5;
        }

        public RandomBool()
        {
            _random = new Random();
        }

        public RandomBool(int seed)
        {
            _random = new Random(seed);
        }
    }
}
