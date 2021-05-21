using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CodeParadise.Core
{
    public sealed class Money : IEquatable<Money>, IComparable<Money>
    {
        private static readonly int[] Cents = {1, 10, 100, 1000};
        private long _amount;


        private Money(long amount, Currency currency)
        {
            _amount = amount;
            Currency = currency;
        }

        public Money(double amount, Currency currency) : this(new decimal(amount), currency)
        {
        }

        public Money(decimal amount, Currency currency, MidpointRounding roundingMode = MidpointRounding.ToEven)
        {
            Currency = currency;
            _amount = Rounding(amount * GetCentFactor(), roundingMode);
        }

        public decimal Amount => (decimal) _amount / Cents[Currency.GetDefaultFractionDigits()];

        public Currency Currency { get; }

        public int CompareTo(Money other)
        {
            if (ReferenceEquals(null, other)) return 1;

            CheckSameCurrency(other);
            if (_amount < other._amount) return -1;

            return _amount == other._amount ? 0 : 1;
        }


        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _amount == other._amount && Equals(Currency, other.Currency);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Money other && Equals(other);
        }

        public Money[] Allocate(int n)
        {
            var lowResult = NewMoney(_amount / n);
            var highResult = NewMoney(lowResult._amount + 1);
            var results = new Money[n];
            var remainder = (int) _amount % n;
            for (var i = 0; i < remainder; ++i) results[i] = highResult;

            for (var i = remainder; i < n; ++i) results[i] = lowResult;

            return results;
        }

        public Money[] Allocate(long[] ratios)
        {
            var total = ratios.Sum();
            var remainder = _amount;
            var results = new Money[ratios.Length];
            for (var i = 0; i < results.Length; ++i)
            {
                results[i] = NewMoney(_amount * ratios[i] / total);
                remainder -= results[i]._amount;
            }

            for (long i = 0; i < remainder; ++i) results[i]._amount++;

            return results;
        }

        private static long Rounding(decimal amount, MidpointRounding roundingMode)
        {
            return (long) Math.Round(amount, 0, roundingMode);
        }

        /// <summary>
        ///     Currency is USD
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Money Dollars(double amount)
        {
            return new Money(amount, Currency.USD);
        }

        /// <summary>
        ///     Currency is USD
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Money Dollars(decimal amount)
        {
            return new Money(amount, Currency.USD);
        }

        private int GetCentFactor()
        {
            return Cents[Currency.GetDefaultFractionDigits()];
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        [SuppressMessage("SonarLint", "S2328")]
        public override int GetHashCode()
        {
            return (int) (_amount ^ (_amount >> 32));
        }

        private void CheckSameCurrency(Money other)
        {
            if (!Currency.Equals(other.Currency)) throw new ArgumentException("Money math mismatch");
        }

        private Money NewMoney(long amount)
        {
            var money = new Money(amount, Currency);

            return money;
        }

        public Money Multiply(double amount)
        {
            return Multiply(Convert.ToDecimal(amount));
        }

        public Money Multiply(decimal amount)
        {
            return Multiply(amount, MidpointRounding.ToEven);
        }

        public Money Multiply(decimal amount, MidpointRounding roundingMode)
        {
            return new Money(Amount * amount, Currency, roundingMode);
        }

        public Money Divide(double amount)
        {
            return Divide(Convert.ToDecimal(amount));
        }

        public Money Divide(decimal amount)
        {
            return Divide(amount, MidpointRounding.ToEven);
        }

        public Money Divide(decimal amount, MidpointRounding roundingMode)
        {
            return new Money(Amount / amount, Currency, roundingMode);
        }

        public Money Add(Money other)
        {
            CheckSameCurrency(other);
            return NewMoney(_amount + other._amount);
        }

        public Money Subtract(Money other)
        {
            CheckSameCurrency(other);
            return NewMoney(_amount - other._amount);
        }

        public static bool operator ==(Money left, Money right)
        {
            if (ReferenceEquals(left, null)) return ReferenceEquals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !(left == right);
        }

        public static bool operator <(Money left, Money right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Money left, Money right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Money left, Money right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Money left, Money right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }

        public static Money operator +(Money a, Money b)
        {
            return a.Add(b);
        }

        public static Money operator -(Money a, Money b)
        {
            return a.Subtract(b);
        }

        public static Money operator *(Money a, decimal multiplier)
        {
            return a.Multiply(multiplier);
        }

        public static Money operator *(Money a, double multiplier)
        {
            return a.Multiply(multiplier);
        }

        public static Money operator /(Money a, decimal divisor)
        {
            return a.Divide(divisor);
        }

        public static Money operator /(Money a, double divisor)
        {
            return a.Divide(divisor);
        }
    }
}