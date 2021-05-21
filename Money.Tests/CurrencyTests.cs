using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace CodeParadise.Core.Tests
{
    public class CurrencyTests
    {

#pragma warning disable S1764 // Identical expressions should not be used on both sides of a binary operator
        [Test]
        [SuppressMessage("ReSharper", "EqualExpressionComparison")]
        public void TwoCurrency_SameName_GetHashCodeEquals()
        {
            Assert.IsTrue(Currency.USD.GetHashCode() == Currency.USD.GetHashCode());

        }
#pragma warning restore S1764 // Identical expressions should not be used on both sides of a binary operator

        [Test]
        public void TwoCurrency_DifferentName_GetHashCodeNotEquals()
        {
            Assert.IsFalse(Currency.USD.GetHashCode() == Currency.JPY.GetHashCode());
        }

        [Test]
        public void Currency_ToString_ReturnCorrect()
        {
            Assert.AreEqual("USD", Currency.USD.ToString());
        }
    }
}