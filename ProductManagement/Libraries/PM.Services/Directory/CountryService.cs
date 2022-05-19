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
    /// Country service
    /// </summary>
    public partial class CountryService : ICountryService
    {
        private readonly ICacheService _cache;
        private readonly IRepository<Country> _countryRepository;

        public CountryService(ICacheService cache, IRepository<Country> countryRepository)
        {
            _cache = cache;
            _countryRepository = countryRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task InsertCountry(Country country)
        {
            if (country == null)
                throw new ArgumentNullException("country");

            await _countryRepository.AddAsync(country);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task UpdateCountry(Country country)
        {
            if (country == null)
                throw new ArgumentNullException("country");

            await _countryRepository.UpdateAsync(country);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task DeleteCountry(Country country)
        {
            if (country == null)
                throw new ArgumentNullException("country");

            await _countryRepository.RemoveAsync(country);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public virtual async Task DeleteCountryById(int countryId)
        {
            if (countryId < 0)
                throw new ArgumentNullException("countryId");

            var entity = await _countryRepository.GetByIdAsync(countryId);
            if (entity == null)
                throw new Exception("Not found country");

            await _countryRepository.RemoveAsync(entity);
        }

        public virtual async Task<IEnumerable<Country>> GetAllCountries(bool showHidden = false)
        {
            if (showHidden)
            {
                return await _countryRepository.FindAsync(row => row.Active);
            }
            else
            {
                return await _countryRepository.GetAllAsync();
            }
        }
    }
}
