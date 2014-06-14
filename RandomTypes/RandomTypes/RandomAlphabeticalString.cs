using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomTypes
{
    public class RandomAlphabeticalString: IRandomType<string>
    {
        Random _random = new Random();

        private readonly char[] Alphabet = new []        
        { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
          'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        
        private int MinLength;
        private int MaxLength;

        public RandomAlphabeticalString(int minLength, int maxLength)
        {
            this.MinLength = minLength;
            this.MaxLength = maxLength;
        }

        public String GetNext()
        {
            int size = _random.Next(MinLength, MaxLength);
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
