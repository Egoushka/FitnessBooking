using System;

namespace FitnessBooking.Core.Enums
{
    [Flags]
    public enum Roles
    {
        Visitor = 1,
        Administrator = 2,
        Coach = 3
    }
}