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
        /// Inserts a country
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
        /// Updates the country
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
        /// Delete the country
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
        /// Delete country by id
        /// </summary>
        /// <param name="countryId">Country identifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public virtual async Task DeleteCountryById(int countryId)
        {
            if (countryId < 0)
                throw new ArgumentNullException("countryId");

            var entity = _countryRepository.GetById(countryId);
            if (entity == null)
                throw new Exception("Not found country");

            await _countryRepository.RemoveAsync(entity);
        }

        /// <summary>
        /// Gets all countries
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Country>> GetAllCountries(bool showHidden = false)
        {
            if (showHidden)
            {
                return _countryRepository.Find(row => row.Active);
            }
            else
            {
                return _countryRepository.GetAll();
            }
        }

        /// <summary>
        /// Gets a country 
        /// </summary>
        /// <param name="countryId">Country identifier</param>
        /// <returns>Country</returns>
        public virtual async Task<Country> GetCountryById(int countryId)
        {
            if (countryId <= 0)
                return null;

            return _countryRepository.GetById(countryId);
        }

        /// <summary>
        /// Gets a country by two letter ISO code
        /// </summary>
        /// <param name="twoLetterIsoCode">Country two letter ISO code</param>
        /// <returns>Country</returns>
        public virtual async Task<Country> GetCountryByTwoLetterIsoCode(string twoLetterIsoCode)
        {
            return _countryRepository.Single(i => i.TwoLetterIsoCode == twoLetterIsoCode);
        }
    }
}
