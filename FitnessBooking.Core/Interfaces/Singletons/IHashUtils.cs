using FitnessBooking.Core.Interfaces.Infrastructure;

namespace FitnessBooking.Core.Interfaces.Singletons
{
    public interface IHashUtils : ISingletonService
    {
        string GetHash(string input);

        bool VerifyHash(string input, string hash);
    }
}