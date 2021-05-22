using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace CodeParadise.Money.Tests
{
    public class MoneyTests
    {
        private Money d15;
        private Money d2_51;
        private Money d0_83;
        private Money d0_84;
        private Money y50;
        private Money e2_51;
        private Money d100;
        private Money d100_Copy;
        private Money d20;
        private Money d80;
        private Money d97_49;

        [SetUp]
        public void Initialize()
        {
            d15 = new Money(15.0m, Currency.USD);
            d2_51 = new Money(2.51m, Currency.USD);
            e2_51 = new Money(2.51m, Currency.EUR);
            y50 = new Money(50m, Currency.JPY);
            d100 = new Money(100.0m, Currency.USD);
            d100_Copy = new Money(100.0m, Currency.USD);
            d20 = new Money(20.0m, Currency.USD);
            d0_83 = new Money(0.83m, Currency.USD);
            d0_84 = new Money(0.84m, Currency.USD);
            d80 = new Money(80.0m, Currency.USD);
            d97_49 = new Money(97.49m, Currency.USD);
        }

        [Test]
        public void Test_Multiply_decimal()
        {
            Assert.AreEqual(Money.Dollars(150m), d15.Multiply(10m));
            Assert.AreEqual(Money.Dollars(1.5m), d15.Multiply(0.1m));
            Assert.AreEqual(Money.Dollars(70m), d100.Multiply(0.7m));
        }

        [Test]
        public void Test_OperatorMultiply_decimal()
        {
            Assert.AreEqual(Money.Dollars(150m), d15 * 10m);
            Assert.AreEqual(Money.Dollars(1.5m), d15 * 0.1m);
            Assert.AreEqual(Money.Dollars(70m), d100 * 0.7m);
        }

        [Test]
        public void Test_Multiply_double()
        {
            Assert.AreEqual(Money.Dollars(150d), d15.Multiply(10d));
            Assert.AreEqual(Money.Dollars(1.5d), d15.Multiply(0.1d));
            Assert.AreEqual(Money.Dollars(70d), d100.Multiply(0.7d));
        }


        [Test]
        public void Test_OperatorMultiply_double()
        {
            Assert.AreEqual(Money.Dollars(150d), d15 * 10d);
            Assert.AreEqual(Money.Dollars(1.5d), d15 * 0.1d);
            Assert.AreEqual(Money.Dollars(70d), d100 * 0.7d);
        }

        [Test]
        public void Test_Divide_decimal()
        {
            Assert.AreEqual(d15, Money.Dollars(150m).Divide(10m));
            Assert.AreEqual(d15, Money.Dollars(1.5m).Divide(0.1m));
            Assert.AreEqual(d100, Money.Dollars(70m).Divide(0.7m));
        }

        [Test]
        public void Test_OperatorDivide_decimal()
        {
            Assert.AreEqual(d15, Money.Dollars(150m) / 10m);
            Assert.AreEqual(d15, Money.Dollars(1.5m) / 0.1m);
            Assert.AreEqual(d100, Money.Dollars(70m) / 0.7m);
        }

        [Test]
        public void Test_Divide_double()
        {
            Assert.AreEqual(d15, Money.Dollars(150d).Divide(10d));
            Assert.AreEqual(d15, Money.Dollars(1.5d).Divide(0.1d));
            Assert.AreEqual(d100, Money.Dollars(70d).Divide(0.7d));
        }


        [Test]
        public void Test_OperatorDivide_double()
        {
            Assert.AreEqual(d15, Money.Dollars(150d) / 10d);
            Assert.AreEqual(d15, Money.Dollars(1.5d) / 0.1d);
            Assert.AreEqual(d100, Money.Dollars(70d) / 0.7d);
        }

        [Test]
        public void Test_Create_FromDouble()
        {
            Assert.AreEqual(d15, new Money(15.0, Currency.USD));
            Assert.AreEqual(d2_51, new Money(2.51, Currency.USD));
            Assert.AreEqual(y50, new Money(50.1, Currency.JPY));
            Assert.AreEqual(d100, new Money(100, Currency.USD));
        }

        [Test]
        public void Test_JPY()
        {
            Money y80 = new Money(80m, Currency.JPY);
            Money y30 = new Money(30, Currency.JPY);
            Assert.AreEqual(y80, y50.Add(y30));
            Assert.AreEqual(y80, y50.Multiply(1.6));
        }

        [Test]
        public void Test_Multiply_Rounding()
        {
            Assert.AreEqual(Money.Dollars(66.67), d100.Multiply(0.66666667));
            Assert.AreEqual(Money.Dollars(66.66), d100.Multiply(0.66666667m, MidpointRounding.ToZero));
        }


        [Test]
        public void Test_Divide_Rounding()
        {
            Assert.AreEqual(d100, Money.Dollars(66.67).Divide(0.66666667));
            Assert.AreEqual(Money.Dollars(99.99), Money.Dollars(66.66).Divide(0.66666667m, MidpointRounding.ToEven));
        }

        [Test]
        public void CompareTo_With_DifferentCurrency_ThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            { 
                d15.CompareTo(e2_51);
            }, "Money math mismatch");
        }

        [Test]
        public void CompareTo_With_SameCurrency_ReturnPositive1()
        {
            Assert.AreEqual(1, d100.CompareTo(d15));
        }

        [Test]
        public void CompareTo_With_SameCurrency_ReturnNegative1()
        {
            Assert.AreEqual(-1, d2_51.CompareTo(d15));
        }

        [Test]
        public void CompareTo_With_SameCurrency_Return0()
        {
            Assert.AreEqual(0, d100.CompareTo(new Money(100m, Currency.USD)));
        }

        [Test]
        public void OperatorGreaterThanOrEquals_TwoNulls_ReturnTrue()
        {
            // arrange
            Money m1 = null;
            Money m2 = null;

            // act && assert
            Assert.IsTrue(m1 >= m2);
        }

        [Test]
        public void OperatorGreaterThanOrEquals_LeftNull_RightMoney_ReturnFalse()
        {
            // arrange
            Money m1 = null;

            // act && assert
            Assert.IsFalse(m1 >= d100);
        }

        [Test]
        public void OperatorGreaterThanOrEquals_LeftMoney_RightNull_ReturnTrue()
        {
            // arrange
            Money m2 = null;

            // act && assert
            Assert.IsTrue(d100 >= m2);
        }

        [Test]
        public void OperatorGreaterThanOrEquals_LeftRightMoney_ReturnTrue()
        {
            Assert.IsTrue(d100 >= d100_Copy);
            Assert.IsTrue(d100 >= d0_84);
        }

        [Test]
        public void OperatorGreaterThanOrEquals_LeftRightMoney_ReturnFalse()
        {
            Assert.IsFalse(d20 >= d100);
            Assert.IsFalse(d2_51 >= d97_49);
        }

        [Test]
        public void OperatorGreaterThan_LeftNull_RightMoney_ReturnFalse()
        {
            // arrange
            Money m1 = null;

            // act && assert
            Assert.IsFalse(m1 > d100);
        }

        [Test]
        public void OperatorGreaterThan_TwoNulls_ReturnFalse()
        {
            // arrange
            Money m1 = null;
            Money m2 = null;

            // act && assert
            Assert.IsFalse(m1 > m2);
        }

        [Test]
        public void OperatorGreaterThan_LeftMoney_RightNull_ReturnTrue()
        {
            // arrange
            Money m2 = null;

            Assert.IsTrue(d100 > m2);
        }

        [Test]
        public void OperatorSmallerThanOrEquals_TwoNulls_ReturnTrue()
        {
            // arrange
            Money m1 = null;
            Money m2 = null;

            // act && assert
            Assert.IsTrue(m1 <= m2);
        }

        [Test]
        public void OperatorSmallerThanOrEquals_LeftNull_RightMoney_ReturnTrue()
        {
            // arrange
            Money m1 = null;

            // act && assert
            Assert.IsTrue(m1 <= d100);
        }

        [Test]
        public void OperatorSmallerThanOrEquals_LeftMoney_RightNull_ReturnFalse()
        {
            // arrange
            Money m2 = null;

            // act && assert
            Assert.IsFalse(d100 <= m2);
        }

        [Test]
        public void OperatorSmallerThanOrEquals_LeftRightMoney_ReturnTrue()
        {
            Assert.IsTrue(d100 <= d100_Copy);
            Assert.IsTrue(d0_84 <= d100);
        }

        [Test]
        public void OperatorSmallerThanOrEquals_LeftRightMoney_ReturnFalse()
        {
            Assert.IsFalse(d100 <= d20);
            Assert.IsFalse(d97_49 <= d2_51);
        }

        [Test]
        public void OperatorSmallerThan_LeftNull_RightMoney_ReturnTrue()
        {
            // arrange
            Money m1 = null;

            // act && assert
            Assert.IsTrue(m1 < d100);
        }

        [Test]
        public void OperatorSmallerThan_TwoNulls_ReturnFalse()
        {
            // arrange
            Money m1 = null;
            Money m2 = null;

            // act && assert
            Assert.IsFalse(m1 < m2);
        }

        [Test]
        public void OperatorSmallerThan_LeftMoney_RightNull_ReturnFalse()
        {
            // arrange
            Money m2 = null;

            Assert.IsFalse(d100 < m2);
        }

        [Test]
        public void GetHashCode_With_SameCurrencySameAmount_Equals()
        {
            Assert.IsTrue(d100.GetHashCode() == new Money(100m, Currency.USD).GetHashCode());
        }

        [Test]
        public void GetHashCode_With_SameCurrencyDifferentAmount_NotEquals()
        {
            Assert.IsTrue(d100.GetHashCode() != d2_51.GetHashCode());
        }

        [Test]
        public void Equals_With_Boxing_SameCurrencySameAmount_ReturnTrue()
        {
            object new100d = new Money(100m, Currency.USD);
            Assert.IsTrue(d100.Equals(new100d));
        }

        [Test]
        public void Equals_With_Boxing_SameCurrencyDifferentAmount_ReturnFalse()
        {
            object new22d = new Money(22m, Currency.USD);
            Assert.IsFalse(d100.Equals(new22d));
        }

        [Test]
        public void Equals_With_Boxing_DifferentObject_ReturnFalse()
        {
            object dummy = new object();
            Assert.IsFalse(d100.Equals(dummy));
        }

        [Test]
        public void Equals_With_null_ReturnFalse()
        {
            Assert.IsFalse(d100.Equals(null));
        }

        [Test]
        public void EqualsOperator_With_null_ReturnFalse()
        {
            Assert.IsFalse(d100 == null);
        }

        [Test]
        public void Equals_With_Self_ReturnTrue()
        {
            Assert.IsTrue(d100.Equals(d100));
        }

#pragma warning disable CS1718
        [Test]
        [SuppressMessage("SonarLint", "S1764")]
        public void EqualsOperator_With_Self_ReturnTrue()
        {

            Assert.IsTrue(d100 == d100);
        }
#pragma warning restore CS1718

        [Test]
        public void EqualsOperator_With_SameCurrencySameAmount_ReturnTrue()
        {
            Assert.IsTrue(d100 == d100_Copy);
        }

        [Test]
        public void EqualsOperator_With_TwoNulls_ReturnTrue()
        {
            // arrange
            Money m1 = null;
            Money m2 = null;

            Assert.IsTrue(m1 == m2);
        }

        [Test]
        public void UnequalOperator_With_null_ReturnTrue()
        {
            Assert.IsTrue(d100 != null);
        }

#pragma warning disable CS1718
        [Test]
        [SuppressMessage("SonarLint", "S1764")]
        public void UnequalOperator_With_Self_ReturnFalse()
        {
            Assert.IsFalse(d100 != d100);
        }
#pragma warning restore CS1718

        [Test]
        public void UnequalOperator_With_SameCurrencySameAmount_ReturnFalse()
        {
            Assert.IsFalse(d100 != d100_Copy);
        }

        [Test]
        public void UnequalOperator_With_TwoNulls_ReturnFalse()
        {
            // arrange
            Money m1 = null;
            Money m2 = null;

            Assert.IsFalse(m1 != m2);
        }

        [Test]
        public void Allocate_With_Divisible_ReturnCorrectMoney()
        {
            // arrange + act
            Money[] allocations = d100.Allocate(5);

            Assert.AreEqual(5, allocations.Length);
            for (int i = 0; i < allocations.Length; ++i)
            {
                Assert.AreEqual(d20, allocations[i]);
            }
        }

        [Test]
        public void Allocate_With_NotDivisible_ReturnCorrectMoney()
        {
            // arrange + act
            Money[] allocations = d2_51.Allocate(3);

            Assert.AreEqual(3, allocations.Length);
            Assert.AreEqual(d0_84, allocations[0]);
            Assert.AreEqual(d0_84, allocations[1]);
            Assert.AreEqual(d0_83, allocations[2]);
        }

        [Test]
        public void Allocate_With_Ratios_ReturnCorrectMoney()
        {
            // arrange + act
            long[] allocation = {3, 7};
            Money[] allocations = Money.Dollars(0.05).Allocate(allocation);

            Assert.AreEqual(Money.Dollars(0.02), allocations[0]);
            Assert.AreEqual(Money.Dollars(0.03), allocations[1]);
        }

        [Test]
        public void Add_ReturnCorrectResult()
        {
            Assert.AreEqual(d100, d80.Add(d20));
            Assert.AreEqual(d100, d2_51.Add(d97_49));
        }

        [Test]
        public void OperatorAdd_ReturnCorrectResult()
        {
            Assert.AreEqual(d100, d80 + d20);
            Assert.AreEqual(d100, d2_51 + d97_49);
        }

        [Test]
        public void Subtract_ReturnCorrectResult()
        {
            Assert.AreEqual(d20, d100.Subtract(d80));
            Assert.AreEqual(d2_51, d100.Subtract(d97_49));
        }

        [Test]
        public void OperatorSubtract_ReturnCorrectResult()
        {
            Assert.AreEqual(d20, d100 - d80);
            Assert.AreEqual(d2_51, d100 - d97_49);
        }

        [Test]
        public void SameCurrency_Equals_ReturnTrue()
        {
            Assert.IsTrue(d100.Currency.Equals(d20.Currency));
        }

        [Test]
        public void DifferentCurrency_Equals_ReturnFalse()
        {
            Assert.IsFalse(d100.Currency.Equals(y50.Currency));
        }
    }
}