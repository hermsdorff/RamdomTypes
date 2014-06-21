using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Mail;

namespace Tests
{
    using RandomTypes;
    using System.Text.RegularExpressions;

    [TestClass]
    public class RandomTypesTests
    {
        const int MinLength = 10;
        const int MaxLength = 20;

        [TestMethod]
        public void RandomBoolTest()
        {
            var random = new RandomBool(20);

            var randFalse = random.GetNext();
            var randTrue = random.GetNext();
            
            Assert.IsTrue(randTrue);
            Assert.IsFalse(randFalse);
        }

        [TestMethod]
        public void RandomIntTest()
        {
            var random = new RandomInt();

            var integer = random.GetNext();

            Assert.IsInstanceOfType(integer, typeof(int));
        }

        [TestMethod]
        public void RandomIntWithLimits()
        {
            const int Min = -100;
            const int Max = 100;
            
            var random = new RandomInt(Min, Max);
            var integer = random.GetNext();

            Assert.IsTrue(integer >= Min && integer <= Max);
        }

        [TestMethod]
        public void RandomAlphabeticalStringTest()
        {
            var random = new RandomAlphabeticalString(MinLength, MaxLength);
            var text = random.GetNext();

            Assert.IsTrue(text.Length >= MinLength);
            Assert.IsTrue(text.Length <= MaxLength);
        }

        [TestMethod]
        public void RandomAlphaNumericStringTest()
        {
            var random = new RandomAlphaNumericString(MinLength, MaxLength);
            var text = random.GetNext();

            Assert.IsTrue(text.Length >= MinLength);
            Assert.IsTrue(text.Length <= MaxLength);
        }

        [TestMethod]
        public void RandomEmailAddressTest()
        {
            var regex = new Regex(@"^([A-Za-z]{3,10})@([A-Za-z]{3,10})((\.[A-Za-z]{2,3})+)$");

            var random = new RandomEmailAddress();
            string email = random.GetNext();

            Match match = regex.Match(email);
            Assert.IsTrue(match.Success);
        }
    }
}
