using System;

namespace Money
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public string CurrencyCode { get; private set; }

        public Money(decimal amount, string currencyCode = "GBP")
        {
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public static implicit operator Money(decimal amount)
        {
            return new Money(amount);
        }

        public static bool operator >(Money firstAmount, Money secondAmount)
        {
            if (firstAmount.CurrencyCode != secondAmount.CurrencyCode)
                throw new InvalidOperationException("Cannot compare different currency types!");

            return firstAmount.Amount > secondAmount.Amount;
        }

        public static bool operator <(Money firstAmount, Money secondAmount)
        {
            if (firstAmount.CurrencyCode != secondAmount.CurrencyCode)
                throw new InvalidOperationException("Cannot compare different currency types!");

            return firstAmount.Amount < secondAmount.Amount;
        }

        public static Money operator +(Money firstAmount, Money secondAmount)
        {
            if (firstAmount.CurrencyCode != secondAmount.CurrencyCode)
                throw new InvalidOperationException("Cannot add two different currency types!");

            return new Money(firstAmount.Amount + secondAmount.Amount, firstAmount.CurrencyCode);
        }

        public static Money operator -(Money firstAmount, Money secondAmount)
        {
            if (firstAmount.CurrencyCode != secondAmount.CurrencyCode)
                throw new InvalidOperationException("Cannot subtract two different currency types!");

            return new Money(firstAmount.Amount - secondAmount.Amount, firstAmount.CurrencyCode);
        }

        public static Money operator *(Money firstAmount, Money secondAmount)
        {
            if (firstAmount.CurrencyCode != secondAmount.CurrencyCode)
                throw new InvalidOperationException("Cannot multiply two different currency types!");

            return new Money(firstAmount.Amount * secondAmount.Amount, firstAmount.CurrencyCode);
        }

        public static Money operator /(Money firstAmount, Money secondAmount)
        {
            if (firstAmount.CurrencyCode != secondAmount.CurrencyCode)
                throw new InvalidOperationException("Cannot divide two different currency types!");

            return new Money(firstAmount.Amount / secondAmount.Amount, firstAmount.CurrencyCode);
        }
    }
}
