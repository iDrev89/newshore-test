

namespace Application.Common.Interfaces
{
    public interface ICurrencyConverterService
    {
        decimal ConvertCurrency(decimal amount, string currency);
    }
}
