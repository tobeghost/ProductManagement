using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Directory
{
    public partial interface IStateProvinceService
    {
        Task InsertStateProvince(StateProvince stateProvince);
        Task UpdateStateProvince(StateProvince stateProvince);
        Task DeleteStateProvince(StateProvince stateProvince);
        Task DeleteStateProvinceById(int stateProvinceId);
        Task<IEnumerable<StateProvince>> GetAllStateProvinces(bool showHidden = false);
        Task<IEnumerable<StateProvince>> GetAllStateProvincesByCountryId(int countryId, bool showHidden = false);
        Task<StateProvince> GetStateProvinceById(int stateProvinceId);
    }
}
