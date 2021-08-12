using System;

namespace FitnessBooking.Core.Interfaces.Infrastructure
{
    public interface IExecutionContext : ISingletonService
    {
        DateTime GetDate();

        string GetLoginName();
    }
}