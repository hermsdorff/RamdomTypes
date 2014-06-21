using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomTypes
{

    public class RandomEmailAddress: IRandomType<string>
    {
        IRandomType<string> _account;
        IRandomType<string> _domain;
        IRandomType<string> _sufix;

        public RandomEmailAddress()
            : this(new RandomAlphabeticalString(3, 10), new RandomAlphabeticalString(3, 10), new RandomAlphabeticalString(2, 3))
        {

        }

        public RandomEmailAddress(IRandomType<string> account = null, IRandomType<string> domain = null, IRandomType<string> sufix = null)
        {
            _account = account;
            _domain = domain;
            _sufix = sufix;
        }

        public string GetNext()
        {
            return String.Format("{0}@{1}.{2}", _account.GetNext(), _domain.GetNext(), _sufix.GetNext());
        }
    }
}
