using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomTypes
{
    public class RandomAlphaNumericString : IRandomType<string>
    {
        RandomString _randomString;
        Random _random = new Random();

        private readonly char[] Alphabet = new[]        
        { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
          'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
          '0','1','2','3','4','5','6','7','8','9'};
        
        public RandomAlphaNumericString(int minLength, int maxLength)
        {
            _randomString = new RandomString(minLength, maxLength, Alphabet);
        }

        public string GetNext()
        {
            return _randomString.GetNext();
        }
    }
}
