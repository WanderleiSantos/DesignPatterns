using System;
using FactoryMethod.Domain.Base;
using FactoryMethod.Domain.Enums;

namespace FactoryMethod.Domain
{
    public sealed class PaymentSlipTransaction : TransactionBase
    {
        public string DocumentNumber { get; private set; }
        public string BarCode { get; private set; }
        public DateTime DueDate { get; private set; }

        PaymentSlipTransaction(double amount, string documentNumber, string barCode, DateTime dueDate)
            : base(TransactionType.PaymentSlip, amount)
        {
            DocumentNumber = documentNumber;
            BarCode = barCode;
            DueDate = dueDate;
        }
    }
}