using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestExpenseJson request)
    {
        Validate(request);

        return new ResponseRegisteredExpenseJson
        {
            Title = request.Title
        };
    }

    private void Validate(RequestExpenseJson request)
    {
        // Com o WhiteSpace ele vai considerar vazio se tiver só espaços
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty)
        {
            throw new ArgumentException("The title is required.");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("The Amount must be greater than zero.");
        }

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (result > 0)
        {
            throw new ArgumentException("The Date cannot be in the future.");
        }

        var paymentTypesIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        if (paymentTypesIsValid == false)
        {
            throw new ArgumentException("Payment Type is not Valid.");
        }
    }
}
