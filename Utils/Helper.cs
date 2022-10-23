using System;
using System.Collections.Generic;
using System.Linq;
using Formula_1_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula_1_App.Utils
{
    public static class Helper
    {
        public static List<T> SetModelIds<T>(List<T> models) where T : IEntity
        {
            int i = 1;

            models.ForEach(m => {
                m.Id = i++;
            });

            return models;
        }        
    }
}
