using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formula_1_API.Controllers;
using Formula_1_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula_1_API.Factories
{
    public class EntityCollectionLabelFactory
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

            var collectionLabels = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => type.IsAssignableFrom(t) && !t.IsAbstract && !_excludedControllers.Contains(t))
                .Select(c => FormatToCollectionLabel(c.Name));

            return FindClosestMatch<T>(collectionLabels) ?? throw new NullReferenceException("An error occured during the CollectionLabel generation");
        }

        public IEnumerable<string> CreateAllLabels()
        {
            var entityControllerType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t =>
                    t.IsAssignableFrom(_controllerBaseType) &&
                    !t.IsAbstract &&
                    !_excludedControllers.Contains(t));

            return entityControllerType.Select(c => FormatToCollectionLabel(c.Name));
        }

        private static string FormatToCollectionLabel(string entityControllerType)
        {
            return entityControllerType.Replace("Controller", string.Empty);
        }

        private static string? FindClosestMatch<T>(IEnumerable<string>? collectionLabels) where T : class, IEntity
        {
            var matchingLabels = collectionLabels?.Where(label => label.Contains(typeof(T).Name));
            var minLength = matchingLabels?.Min(label => label.Length);
            return matchingLabels?.Single(label => label.Length == minLength);
        }
    }
}