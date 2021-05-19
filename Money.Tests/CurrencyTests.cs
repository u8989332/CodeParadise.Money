using System;
using NUnit.Framework;

namespace Money.Tests
{
    public class CurrencyTests
    {

        [Test]
        public void TwoCurrency_SameName_GetHashCodeEquals()
        {
            Assert.IsTrue(Currency.USD.GetHashCode() == Currency.USD.GetHashCode());
        }

        [Test]
        public void TwoCurrency_DifferentName_GetHashCodeNotEquals()
        {
            Assert.IsFalse(Currency.USD.GetHashCode() == Currency.JPY.GetHashCode());
        }
    }
}