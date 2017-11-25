using System.Xml.Serialization;
using ClassLibrary.Implementations;
using ClassLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClassLibrary.Extensions
{
    public static class DIExtensions
    {
        public static void UseGusAnalyzer(this IServiceCollection services)
        {
            services.AddTransient<IGusAnalyzer, GusAnalyzer>();
            services.AddTransient<ITERCAnalyzer, TERCAnalyzer>();
            services.AddTransient<ISIMCAnalyzer, SIMCAnalyzer>();
            services.AddTransient<IULICAnalyzer, ULICAnalyzer>();
        }
    }
}