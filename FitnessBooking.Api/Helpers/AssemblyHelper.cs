using Autofac.Extensions.DependencyInjection;
using System.Reflection;

namespace FitnessBooking.Api.Helpers
{
    public static class AssemblyHelper
    {
        public static Assembly[] GetSolutionAssemblies()
        {
            return new[]
            {
                typeof(ServiceCollectionExtensions).Assembly,
                typeof(Business.Infrastructure.IRegisterDependency).Assembly,
                typeof(Core.Interfaces.Infrastructure.IRegisterDependency).Assembly,
                typeof(Data.Infrastructure.IRegisterDependency).Assembly
            };
        }
    }
}