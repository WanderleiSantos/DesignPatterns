using System;
using FactoryMethod.Domain;
using FactoryMethod.Domain.Enums;
using FactoryMethod.Manager.Factory;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            #region CreditCard Transaction
            
            var creditCardTransactionProcessor =
                TransactionProcessorFactory.CreateTransactionProcessor(TransactionType.CreditCard);

            var creditCardTransaction = new CreditCardTransaction(
                60000, "Wanderlei Santos", "222", "1234567896541");
            
            var creditCardTransactionInfo = creditCardTransactionProcessor.Authorize(creditCardTransaction);

            Console.WriteLine($"{creditCardTransactionInfo.Amount} | {creditCardTransactionInfo.CreateDate:g} | " +
                              $"{creditCardTransactionInfo.TransactionKey} | {creditCardTransactionInfo.TransactionStatusType}");

            #endregion

            Console.ReadLine();
        }
    }
}