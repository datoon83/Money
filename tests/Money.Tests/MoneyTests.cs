using FluentAssertions;
using NUnit.Framework;
using System;

namespace Money.Tests
{
    public class MoneyTests
    {
        [Test]
        public void DefaultMoneyShouldBeGBP()
        {
            Money ukMoney = 12.0m;

            Assert.That(ukMoney.CurrencyCode, Is.EqualTo("GBP"));
        }

        [TestCase("GBP")]
        [TestCase("EUR")]
        public void Addition(string currencyCode)
        {
            var firstAmount = new Money(100.0m, currencyCode);
            var secondAmount = new Money(100.0m, currencyCode);

            var result = firstAmount + secondAmount;

            result.CurrencyCode.Should().Be(currencyCode);
            result.Amount.Should().Be(200.0m);
        }

        [TestCase("GBP", "EUR")]
        public void TryAddingTwoDifferentCurrencies(string firstCurrencyCode, string secondCurrencyCode)
        {
            var firstAmount = new Money(100.0m, firstCurrencyCode);
            var secondAmount = new Money(100.0m, secondCurrencyCode);

            Money result = null;

            Assert.Throws<InvalidOperationException>(() => result = firstAmount + secondAmount, "Cannot add two different currency types!");
        }

        [TestCase("GBP")]
        [TestCase("EUR")]
        public void Subtraction(string currencyCode)
        {
            var firstAmount = new Money(100.0m, currencyCode);
            var secondAmount = new Money(50.50m, currencyCode);

            var result = firstAmount - secondAmount;

            result.CurrencyCode.Should().Be(currencyCode);
            result.Amount.Should().Be(49.50m);
        }

        [TestCase("GBP", "EUR")]
        public void TrySubtractingTwoDifferentCurrencies(string firstCurrencyCode, string secondCurrencyCode)
        {
            var firstAmount = new Money(100.0m, firstCurrencyCode);
            var secondAmount = new Money(100.0m, secondCurrencyCode);

            Money result = null;
            Assert.Throws<InvalidOperationException>(() => result = firstAmount - secondAmount, "Cannot subtract two different currency types!");
        }

        [TestCase("GBP")]
        [TestCase("EUR")]
        public void Division(string currencyCode)
        {
            var firstAmount = new Money(100.0m, currencyCode);
            var secondAmount = new Money(10.00m, currencyCode);

            var result = firstAmount / secondAmount;

            result.CurrencyCode.Should().Be(currencyCode);
            result.Amount.Should().Be(10.0m);
        }

        [TestCase("GBP", "EUR")]
        public void TryDividingTwoDifferentCurrencies(string firstCurrencyCode, string secondCurrencyCode)
        {
            var firstAmount = new Money(100.0m, firstCurrencyCode);
            var secondAmount = new Money(100.0m, secondCurrencyCode);

            Money result = null;
            Assert.Throws<InvalidOperationException>(() => result = firstAmount / secondAmount, "Cannot divide two different currency types!");
        }

        [TestCase("GBP")]
        [TestCase("EUR")]
        public void Multiplication(string currencyCode)
        {
            var firstAmount = new Money(100.0m, currencyCode);
            var secondAmount = new Money(10.00m, currencyCode);

            var result = firstAmount / secondAmount;

            result.CurrencyCode.Should().Be(currencyCode);
            result.Amount.Should().Be(10.0m);
        }

        [TestCase("GBP", "EUR")]
        public void TryMultiplyingTwoDifferentCurrencies(string firstCurrencyCode, string secondCurrencyCode)
        {
            var firstAmount = new Money(100.0m, firstCurrencyCode);
            var secondAmount = new Money(100.0m, secondCurrencyCode);

            Money result = null;
            Assert.Throws<InvalidOperationException>(() => result = firstAmount / secondAmount, "Cannot multiply two different currency types!");
        }
    }
}
