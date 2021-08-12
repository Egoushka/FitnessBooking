using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FitnessBooking.Data.Repository.Repositories
{
    public class AdministratorRepository : Repository<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(FitnessBookingContext fitnessBookingContext) : base(fitnessBookingContext)
        {
        }

        public Task<Administrator> GetAdministratorByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}