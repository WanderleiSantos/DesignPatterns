using FactoryMethod.Domain.Base;
using FactoryMethod.Domain.Enums;

namespace FactoryMethod.Domain
{
    public sealed class CreditCardTransaction : TransactionBase
    {
        public string HolderName { get; private set; }
        public string SecurityCode { get; private set; }
        public string CardNumber { get; private set; }

        public CreditCardTransaction(double amount, string holderName, string securityCode, string cardNumber) :
            base(TransactionType.CreditCard, amount)
        {
            HolderName = holderName;
            SecurityCode = securityCode;
            CardNumber = cardNumber;
        }
    }
}