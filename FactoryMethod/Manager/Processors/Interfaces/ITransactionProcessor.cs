using FactoryMethod.Domain;
using FactoryMethod.Domain.Base;

namespace FactoryMethod.Manager.Processors.Interfaces
{
    public interface ITransactionProcessor
    {
        TransactionInfo Authorize(TransactionBase transaction);
    }
}