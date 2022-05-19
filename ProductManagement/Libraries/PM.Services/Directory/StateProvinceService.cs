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
    /// State Province service
    /// </summary>
    public partial class StateProvinceService : IStateProvinceService
    {
        private readonly ICacheService _cache;
        private readonly IRepository<StateProvince> _stateProvinceRepository;

        public StateProvinceService(ICacheService cache, IRepository<StateProvince> stateProvinceRepository)
        {
            _cache = cache;
            _stateProvinceRepository = stateProvinceRepository;
        }

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="stateProvince"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task InsertStateProvince(StateProvince stateProvince)
        {
            if (stateProvince == null)
                throw new ArgumentNullException("stateProvince");

            await _stateProvinceRepository.AddAsync(stateProvince);
        }

        /// <summary>
        /// Updates the state/province
        /// </summary>
        /// <param name="stateProvince"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task UpdateStateProvince(StateProvince stateProvince)
        {
            if (stateProvince == null)
                throw new ArgumentNullException("stateProvince");

            await _stateProvinceRepository.UpdateAsync(stateProvince);
        }

        /// <summary>
        /// Delete the state/province
        /// </summary>
        /// <param name="stateProvince"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task DeleteStateProvince(StateProvince stateProvince)
        {
            if (stateProvince == null)
                throw new ArgumentNullException("stateProvince");

            await _stateProvinceRepository.RemoveAsync(stateProvince);
        }

        /// <summary>
        /// Delete state/province by id
        /// </summary>
        /// <param name="stateProvinceId">State/province identifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public virtual async Task DeleteStateProvinceById(int stateProvinceId)
        {
            if (stateProvinceId < 0)
                throw new ArgumentNullException("stateProvinceId");

            var entity = await _stateProvinceRepository.GetByIdAsync(stateProvinceId);
            if (entity == null)
                throw new Exception("Not found state/province");

            await _stateProvinceRepository.RemoveAsync(entity);
        }

        /// <summary>
        /// Gets all state provinces
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<StateProvince>> GetAllStateProvinces(bool showHidden = false)
        {
            if (showHidden)
            {
                return await _stateProvinceRepository.FindAsync(row => row.Active);
            }
            else
            {
                return await _stateProvinceRepository.GetAllAsync();
            }
        }

        /// <summary>
        /// Gets all state/provinces by country identifier
        /// </summary>
        /// <param name="countryId">country identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<StateProvince>> GetAllStateProvincesByCountryId(int countryId, bool showHidden = false)
        {
            if (showHidden)
            {
                return await _stateProvinceRepository.FindAsync(row => row.CountryId == countryId && row.Active);
            }
            else
            {
                return await _stateProvinceRepository.FindAsync(row => row.CountryId == countryId);
            }
        }

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="stateProvinceId">State province identifier</param>
        /// <returns>StateProvince</returns>
        public virtual async Task<StateProvince> GetStateProvinceById(int stateProvinceId)
        {
            if (stateProvinceId <= 0)
                return null;

            return await _stateProvinceRepository.GetByIdAsync(stateProvinceId);
        }
    }
}
