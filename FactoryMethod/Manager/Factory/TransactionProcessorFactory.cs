using System;
using FactoryMethod.Domain.Enums;
using FactoryMethod.Manager.Processors;
using FactoryMethod.Manager.Processors.Interfaces;

namespace FactoryMethod.Manager.Factory
{
    public class TransactionProcessorFactory
    {
        public static ITransactionProcessor CreateTransactionProcessor(TransactionType transactionType)
        {
            switch (transactionType)
            {
                case TransactionType.CreditCard: return new CrediCardTransactionProcessor();
                case TransactionType.Debit: return new DebitTransactionProcessor();
                case TransactionType.PaymentSlip: return new PaymentSlipTransactionProcessor();

                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}