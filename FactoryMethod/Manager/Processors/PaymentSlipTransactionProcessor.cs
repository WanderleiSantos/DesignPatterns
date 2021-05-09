using System;
using FactoryMethod.Domain;
using FactoryMethod.Domain.Base;
using FactoryMethod.Manager.Processors.Base;
using FactoryMethod.Manager.Processors.Interfaces;

namespace FactoryMethod.Manager.Processors
{
    public class PaymentSlipTransactionProcessor : ProcessorBase<PaymentSlipTransaction>, ITransactionProcessor
    {
        public TransactionInfo Authorize(TransactionBase transaction)
        {
            var paymentSlipTransaction = ValidateTransactionType(transaction);

            return ProcessAuthorization(paymentSlipTransaction);
        }

        private static TransactionInfo ProcessAuthorization(PaymentSlipTransaction paymentSlipTransaction)
        {
            paymentSlipTransaction.SetStatusInProgress();

            BusinessSimulation(ref paymentSlipTransaction);

            return new TransactionInfo(paymentSlipTransaction.TransactionKey,
                paymentSlipTransaction.CreateDate, paymentSlipTransaction.Amount,
                paymentSlipTransaction.TransactionStatusType);
        }

        private static void BusinessSimulation(ref PaymentSlipTransaction paymentSlipTransaction)
        {
            if (paymentSlipTransaction.Amount >= 100
                && paymentSlipTransaction.Amount <= 20000
                && paymentSlipTransaction.DueDate.Date >= DateTime.UtcNow.Date)
            {
                paymentSlipTransaction.SetStatusAuthorized();

                return;
            }

            paymentSlipTransaction.SetStatusUnauthorized();
        }
        
        
    }
}