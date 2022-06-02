using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models;
using FitnessBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessBooking.Data.Repository.Repositories
{
    public class AdministratorRepository : Repository<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(FitnessBookingContext fitnessBookingContext) : base(fitnessBookingContext)
        {
        }
    }
}