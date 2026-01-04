using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    // Validador para o registro de despesas
    public class RegisterExpenseValidator : AbstractValidator<RequestExpenseJson>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required");
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("The Amount must be greater than zero.");
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The Date cannot be in the future.");
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("Payment Type is not Valid.");
        }
    }
}
