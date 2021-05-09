using System;
using FactoryMethod.Domain.Base;

namespace FactoryMethod.Manager.Processors.Base
{
    public abstract class ProcessorBase<T> where T : TransactionBase
    {
        protected T ValidateTransactionType(TransactionBase transaction)
        {
            if (!(transaction is T)) throw new ArgumentException("Invalid Transaction Type");
            return (T) transaction;
        }
    }
}