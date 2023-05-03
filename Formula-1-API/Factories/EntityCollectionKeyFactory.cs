using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formula_1_API.Controllers;
using Formula_1_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula_1_API.Factories
{
    public class EntityCollectionKeyFactory
    {
        private readonly Type[] _excludedControllers = {
            typeof(BaseController<>),
            typeof(MainController),
            typeof(ConfigurationController)
        };

        private readonly IEnumerable<Type> _assemblyTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes());

        private readonly Type _controllerBaseType = typeof(ControllerBase);

        public string CreateSingleLabel<T>() where T : class, IEntity
        {
            var type = typeof(ControllerBase);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => type.IsAssignableFrom(t) &&
                    !t.IsAbstract);

            return types.Select(c => FormatToEntityKey(c.Name))
                .Single(x => x.Contains(typeof(T).Name));
        }

        public IEnumerable<string> CreateAllLabels()
        {
            var entityControllerType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t =>
                    t.IsAssignableFrom(_controllerBaseType) &&
                    !t.IsAbstract &&
                    !_excludedControllers.Contains(t)
                );

            return entityControllerType.Select(c => FormatToEntityKey(c.Name));
        }

        private static string FormatToEntityKey(string entityControllerType)
        {
            return entityControllerType.Replace("Controller", string.Empty);
        }
    }
}