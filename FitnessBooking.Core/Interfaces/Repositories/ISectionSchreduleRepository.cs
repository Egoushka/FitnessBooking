﻿using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models;

namespace FitnessBooking.Core.Interfaces.Repositories
{
    public interface ISectionScheduleRepository : ITransientService, IRepository<SectionSchedule>
    {
    }
}