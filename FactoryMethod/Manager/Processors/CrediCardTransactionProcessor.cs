using FactoryMethod.Domain;
using FactoryMethod.Domain.Base;
using FactoryMethod.Manager.Processors.Base;
using FactoryMethod.Manager.Processors.Interfaces;

namespace FactoryMethod.Manager.Processors
{
    public class CrediCardTransactionProcessor : ProcessorBase<CreditCardTransaction>, ITransactionProcessor
    {
        public TransactionInfo Authorize(TransactionBase transaction)
        {
            var creditCardTransaction = ValidateTransactionType(transaction);
            return ProcessAuthorization(creditCardTransaction);
        }

        private static TransactionInfo ProcessAuthorization(CreditCardTransaction creditCardTransaction)
        {
            creditCardTransaction.SetStatusInProgress();
            BusinessSimulation(ref creditCardTransaction);

            return new TransactionInfo(creditCardTransaction.TransactionKey, creditCardTransaction.CreateDate,
                creditCardTransaction.Amount, creditCardTransaction.TransactionStatusType);
        }

        private static void BusinessSimulation(ref CreditCardTransaction creditCardTransaction)
        {
            if (creditCardTransaction.Amount >= 10 && creditCardTransaction.Amount <= 1200)
            {
                creditCardTransaction.SetStatusAuthorized();
                return;
            }
            
            creditCardTransaction.SetStatusUnauthorized();
        }
    }
}