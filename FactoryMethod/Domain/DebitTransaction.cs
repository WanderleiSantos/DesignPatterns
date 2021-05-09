using FactoryMethod.Domain.Base;
using FactoryMethod.Domain.Enums;

namespace FactoryMethod.Domain
{
    public sealed class DebitTransaction: TransactionBase
    {
        public string BankName { get; private set; }

        public DebitTransaction(double amount, string bankName) : base(TransactionType.Debit, amount)
        {
            BankName = bankName;
        }
    }
}