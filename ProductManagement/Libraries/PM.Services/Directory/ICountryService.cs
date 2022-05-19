using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Directory
{
    public partial interface ICountryService
    {
        Task InsertCountry(Country country);
        Task UpdateCountry(Country country);
        Task DeleteCountry(Country country);
        Task DeleteCountryById(int countryId);
        Task<IEnumerable<Country>> GetAllCountries(bool showHidden = false);
        Task<Country> GetCountryById(int countryId);
        Task<Country> GetCountryByTwoLetterIsoCode(string twoLetterIsoCode);
    }
}
