using System;
using System.Collections.Generic;
using System.Linq;
using Formula_1_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula_1_App.Utils
{
    public static class Helper
    {
        public static List<T> SetModelIds<T>(List<T> models) where T : IIdentifier
        {
            int i = 1;

            models.ForEach(m => {
                m.Id = i++;
            });

            return models;
        }

        public static IEnumerable<string> GetEndpoints()
        {
            var type = typeof(ControllerBase);
            
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => type.IsAssignableFrom(t) && !t.IsAbstract);

            // TODO: Find a better way to exclude the 'BaseController' (Skip())
            var endpoints = types.Select(c => c.Name)
                .Select(n => n.Replace("Controller", ""))
                .Where(n => n != "Base`1" && n != "Main");

            return endpoints;
        }
    }
}
