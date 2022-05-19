using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Directory
{
    public partial interface ICurrencyService
    {
        Task InsertCurrency(Currency currency);
        Task UpdateCurrency(Currency currency);
        Task DeleteCurrency(Currency currency);
        Task DeleteCurrencyById(int currencyId);
        Task<IEnumerable<Currency>> GetAllCurrencies(bool showHidden = false);
        Task<Currency> GetCurrencyById(int currencyId);
        Task<Currency> GetCurrencyByCode(string currencyCode);
    }
}
