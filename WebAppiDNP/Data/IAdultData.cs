using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppiDNP.Models;

namespace WebAppiDNP.Data
{
    public interface IAdultData
    {
        //IList<Adult> getAdults();
        Task <IList<Adult>> GetAdults( string name);
        Task<Adult> AddAdult(Adult adult);
        Task RemoveAdultAsync(int adultId);
        Task<Adult> UpdateAdultAsync(Adult adult);
    }
}