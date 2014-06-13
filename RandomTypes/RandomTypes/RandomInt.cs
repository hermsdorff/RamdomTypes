using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomTypes
{
    public class RandomInt : IRandomType<int>
    {
        private readonly Random _random;

        public int Min { get; private set ; }
        public int Max { get; private set; }

        public RandomInt(int min, int max, int seed):this(seed)
        {
            Min = min;
            Max = max;
        }

        public RandomInt(int min, int max)
            : this()
        {
            Min = min;
            Max = max;
        }

        public RandomInt(int seed): this()
        {
            _random = new Random(seed);
        }

        public RandomInt()
        {
            _random = new Random();

            Min = -2147483648;
            Max = 2147483647;
        }

        #region Implementation of IRandomType<int>

        public int GetNext()
        {
            return _random.Next(Min, Max);
        }

        #endregion
    }
}
