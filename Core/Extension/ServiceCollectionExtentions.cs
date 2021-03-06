using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extension
{
    public static class ServiceCollectionExtentions  
    {
        public static IServiceCollection AddDependencyResolvers 
            (this IServiceCollection serviceCollection, ICoreModule[] coreModules)
        {
            foreach (var module in coreModules)
            {
                module.Load(serviceCollection); 
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
