using System;
using System.Data;
using FactoryMethod.Domain.Enums;

namespace FactoryMethod.Domain.Base
{
    public abstract class TransactionBase
    {
        public TransactionType TransactionType { get; private set; }
        public Guid TransactionKey { get; private set; }
        public DateTime CreateDate { get; private  set; }
        public double Amount { get; private set; }
        public TransactionStatusType TransactionStatusType { get; private set; }

        protected TransactionBase(TransactionType transactionType, double amount)
        {
            TransactionType = transactionType;
            Amount = amount;
            TransactionKey = Guid.NewGuid();
            CreateDate = DateTime.UtcNow;
            TransactionStatusType = TransactionStatusType.Pending;
        }

        public bool SetStatusInProgress()
        {
            StatusTransitionValidate(TransactionStatusType.InProgress);
            this.TransactionStatusType = TransactionStatusType.InProgress;
            return true;
        }

        public bool SetStatusAuthorized()
        {
            StatusTransitionValidate(TransactionStatusType.Authorized);
            this.TransactionStatusType = TransactionStatusType.Authorized;
            return true;
        }

        public bool SetStatusUnauthorized()
        {
            StatusTransitionValidate(TransactionStatusType.Unauthorized);
            this.TransactionStatusType = TransactionStatusType.Unauthorized;
            return true;
        }

        private bool StatusTransitionValidate(TransactionStatusType desiredTransactionStatusType)
        {
            if (this.TransactionStatusType == desiredTransactionStatusType)
            {
                throw new ConstraintException("No transaction status transition");
            }

            if ((int) this.TransactionStatusType < (int) desiredTransactionStatusType)
            {
                throw new ConstraintException("Invalid transaction status transition");
            }

            if ((int) this.TransactionStatusType <= 1)
            {
                throw new ConstraintException("Invalid transaction status transition from end state process");
            }
            
            return true;
        }
    }
}