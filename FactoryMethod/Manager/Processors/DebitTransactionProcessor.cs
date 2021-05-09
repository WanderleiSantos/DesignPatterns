using FactoryMethod.Domain;
using FactoryMethod.Domain.Base;
using FactoryMethod.Manager.Processors.Base;
using FactoryMethod.Manager.Processors.Interfaces;

namespace FactoryMethod.Manager.Processors
{
    public class DebitTransactionProcessor : ProcessorBase<DebitTransaction>, ITransactionProcessor
    {
        public TransactionInfo Authorize(TransactionBase transaction)
        {
            var debitTransaction = ValidateTransactionType(transaction);
            return ProcessAuthorization(debitTransaction);
        }

        private static TransactionInfo ProcessAuthorization(DebitTransaction debitTransaction)
        {
            debitTransaction.SetStatusInProgress();
            BusinessSimulation(ref debitTransaction);
            return new TransactionInfo(debitTransaction.TransactionKey, debitTransaction.CreateDate,
                debitTransaction.Amount, debitTransaction.TransactionStatusType);
        }

        private static void BusinessSimulation(ref DebitTransaction debitTransaction)
        {
            if (debitTransaction.Amount >= 1 && debitTransaction.Amount <= 5000)
            {
                debitTransaction.SetStatusAuthorized();
                return;
            }

            debitTransaction.SetStatusUnauthorized();
        }
    }
}