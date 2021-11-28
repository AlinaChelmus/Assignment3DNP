using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAppDNP.Models;

namespace BlazorAppDNP.Data
{
    public interface IAdultData
    {
        Task <IList<Adult>> GetAdults( string name);
        Task<Adult> AddAdultAsync(Adult adult);
    }
}