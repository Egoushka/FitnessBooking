using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using FitnessBooking.Business.Infrastructure;

namespace FitnessBooking.Api.Helpers
{
    public static class AssemblyHelper
    {
        public static Assembly[] GetSolutionAssemblies()
        {
            return new[]
            {
                typeof(ServiceCollectionExtensions).Assembly,
                typeof(IRegisterDependency).Assembly,
                typeof(Core.Interfaces.Infrastructure.IRegisterDependency).Assembly,
                typeof(Data.Infrastructure.IRegisterDependency).Assembly
            };
        }
    }
}