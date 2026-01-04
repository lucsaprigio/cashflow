namespace CashFlow.Exception.ExceptionsBase
{
    // Documentação: Exceção lançada quando ocorre um erro de validação.

    public class ErrorOnValidationException : CashFlowException
    {
        public List<string> Errors{ get; set; }
        // Documentação: Construtor da exceção de erro de validação que retorna uma lista de mensagens de erro.
        public ErrorOnValidationException(List<string> errorMessages)
        {
            Errors = errorMessages;
        }
    }
}
