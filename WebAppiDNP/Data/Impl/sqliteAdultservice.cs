using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using WebAppiDNP.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebAppiDNP.Data.Impl
{
    public class sqliteAdultservice : IAdultData
    {
        
        private AdultContext context;
        
        public sqliteAdultservice(AdultContext context)
        {
            this.context = context;
        }

        public async Task<IList<Adult>> GetAdults(string name)
        {
            var toReturn = context.Adults.ToList();
            var toRemove = new List<Adult>();
            
            if (name != null)
            {
                foreach (var adult in toReturn)
                {
                    if (adult.FirstName + adult.LastName != name) toRemove.Add(adult);
                }
            }
            foreach (var adult in toRemove) toReturn.Remove(adult);

            return toReturn;
        }

        public async Task<Adult> AddAdult(Adult adult)
        {
            context.Adults.AddAsync(adult);
            return adult;
        }
        public async Task RemoveAdultAsync(int adultId)
        {
            Adult adult = context.Adults.Where(a => a.Id == adultId).First();
            context.Remove(adultId);
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            context.Adults.Update(adult);
            return adult;
        }
    }
}