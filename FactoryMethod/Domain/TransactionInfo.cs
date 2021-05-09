using System;
using FactoryMethod.Domain.Enums;

namespace FactoryMethod.Domain
{
    public class TransactionInfo
    {
        public Guid TransactionKey { get; private set; }
        public DateTime CreateDate { get; private set; }
        public double Amount { get; private set; }
        public TransactionStatusType TransactionStatusType { get; private set; }

        public TransactionInfo(Guid transactionKey, DateTime createDate, double amount, TransactionStatusType transactionStatusType)
        {
            TransactionKey = transactionKey;
            CreateDate = createDate;
            Amount = amount;
            TransactionStatusType = transactionStatusType;
        }
    }
}