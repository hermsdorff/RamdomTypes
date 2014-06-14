using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomTypes
{
    class RandomString : IRandomType<string>
    {
        Random _random = new Random();
        private int _minLength;
        private int _maxLength;
        private char[] Alphabet;

        public RandomString(int minLingth, int maxLength)
        {
            _minLength = minLingth;
            _maxLength = maxLength;

            Alphabet = new char[256];
            for (var i = 0; i < 256; i++)
            {
                Alphabet[i] = (char)i;
            }
        }

        public RandomString(int minLength, int maxLength, char[] alphabet)
            : this(minLength, maxLength)
        {
            Alphabet = alphabet;
        }

        public string GetNext()
        {
            int size = _random.Next(_minLength, _maxLength);
            var result = new StringBuilder();

            for (var i = 0; i < size; i++)
            {
                int position = _random.Next(Alphabet.Length);
                result.Append(Alphabet[position]);
            }

            return result.ToString();
        }
    }
}
