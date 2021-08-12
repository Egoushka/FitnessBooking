﻿using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Infrastructure;
using System.Threading.Tasks;

namespace FitnessBooking.Core.Interfaces.Repositories
{
    public interface ISectionScheduleRepository : ITransientService, IRepository<SectionSchedule>
    {
        Task<SectionSchedule> GetSectionScheduleByIdAsync(int id);
    }
}