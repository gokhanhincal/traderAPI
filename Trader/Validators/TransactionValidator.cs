using FluentValidation;
using Trader.Models;

namespace Trader.Validators
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.TransactionDate).Must(x => x.Day >= 1 && x.Day <= 28)
                .WithMessage("Transaction day must be between 1-28");
            RuleFor(x => x.Amount).Must(x => x >= 100 && x <= 20000)
                .WithMessage("Transaction amount must be between 100 TL - 20.000 TL");
        }
    }
}