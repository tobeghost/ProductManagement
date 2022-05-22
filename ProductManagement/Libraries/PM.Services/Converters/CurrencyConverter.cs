using AutoMapper;
using PM.Services.Directory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Converters
{
    public class CurrencyConverter : IValueConverter<string, int>
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyConverter(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public int Convert(string sourceMember, ResolutionContext context)
        {
            var currency = _currencyService.GetCurrencyByCode(sourceMember).GetAwaiter().GetResult();
            return currency == null ? 0 : currency.Id;
        }
    }
}
