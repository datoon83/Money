using NUnit.Framework;
using System;

namespace Money.Tests
{
    public class MoneyTests
    {
        [Test]
        public void DefaultMoneyShouldBeUK()
        {
            Money ukMoney = 12.0m;

            Assert.That(ukMoney.CurrencyCode, Is.EqualTo("GBP"));
        }

        [TestCase("GBP")]
        [TestCase("EUR")]
        public void Add(string currencyCode)
        {
            var firstAmount = new Money(100.0m, currencyCode);
            var secondAmount = new Money(100.0m, currencyCode);

            var result = firstAmount + secondAmount;

            Assert.That(result.CurrencyCode, Is.EqualTo(currencyCode));
            Assert.That(result.Amount, Is.EqualTo(200.0m));
        }

        [TestCase("GBP", "EUR")]
        public void TryAddingToDifferentCurrencies(string firstCurrencyCode, string secondCurrencyCode)
        {
            var firstAmount = new Money(100.0m, firstCurrencyCode);
            var secondAmount = new Money(100.0m, secondCurrencyCode);

            Money result = null;
            Assert.Throws<InvalidOperationException>(() => result = firstAmount + secondAmount);
        }
    }
}
