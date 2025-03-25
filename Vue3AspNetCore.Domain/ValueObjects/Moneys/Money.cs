using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vue3AspNetCore.Domain.ValueObjects.Moneys
{
    public class Money
    {
        public decimal Amount { get; private set; }

        public string Currency { get; private set; }

        private Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Create(decimal amount, string currency)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative");
            }

            if (string.IsNullOrWhiteSpace(currency))
            {
                throw new ArgumentException("Currency cannot be empty");
            }

            return new Money(amount, currency);
        }

        public Money Add(Money money)
        {
            if (Currency != money.Currency)
            {
                throw new ArgumentException("Currency mismatch");
            }

            return new Money(Amount + money.Amount, Currency);
        }
    }
}