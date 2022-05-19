using PM.Core.Caching;
using PM.Domain.Data;
using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Directory
{
    /// <summary>
    /// Currency service
    /// </summary>
    public partial class CurrencyService : ICurrencyService
    {
        private readonly ICacheService _cache;
        private readonly IRepository<Currency> _currencyRepository;

        public CurrencyService(ICacheService cache, IRepository<Currency> currencyRepository)
        {
            _cache = cache;
            _currencyRepository = currencyRepository;
        }

        /// <summary>
        /// Inserts a currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task InsertCurrency(Currency currency)
        {
            if (currency == null)
                throw new ArgumentNullException("currency");

            await _currencyRepository.AddAsync(currency);
        }

        /// <summary>
        /// Updates the currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task UpdateCurrency(Currency currency)
        {
            if (currency == null)
                throw new ArgumentNullException("currency");

            await _currencyRepository.UpdateAsync(currency);
        }

        /// <summary>
        /// Delete the currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task DeleteCurrency(Currency currency)
        {
            if (currency == null)
                throw new ArgumentNullException("currency");

            await _currencyRepository.RemoveAsync(currency);
        }

        /// <summary>
        /// Delete currency by id
        /// </summary>
        /// <param name="currencyId">Currency identifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public virtual async Task DeleteCurrencyById(int currencyId)
        {
            if (currencyId < 0)
                throw new ArgumentNullException("currencyId");

            var entity = await _currencyRepository.GetByIdAsync(currencyId);
            if (entity == null)
                throw new Exception("Not found currency");

            await _currencyRepository.RemoveAsync(entity);
        }

        /// <summary>
        /// Gets all currencies
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Currency>> GetAllCurrencies(bool showHidden = false)
        {
            if (showHidden)
            {
                return await _currencyRepository.FindAsync(row => row.Active);
            }
            else
            {
                return await _currencyRepository.GetAllAsync();
            }
        }

        /// <summary>
        /// Gets a currency 
        /// </summary>
        /// <param name="currencyId">Currency identifier</param>
        /// <returns>Currency</returns>
        public virtual async Task<Currency> GetCurrencyById(int currencyId)
        {
            if (currencyId <= 0)
                return null;

            return await _currencyRepository.GetByIdAsync(currencyId);
        }

        /// <summary>
        /// Gets a currency by code
        /// </summary>
        /// <param name="currencyCode">Currency code (TRY, USD etc.)</param>
        /// <returns>Currency</returns>
        public virtual async Task<Currency> GetCurrencyByCode(string currencyCode)
        {
            return await _currencyRepository.SingleAsync(i => i.CurrencyCode == currencyCode);
        }
    }
}
