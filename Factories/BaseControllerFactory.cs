using System;
using Formula_1_App.Controllers;
using Formula_1_App.Models;
using Formula_1_App.Services;
using Formula_1_App.Services.Interfaces;

namespace Formula_1_App.Factories
{
    public class BaseControllerFactory
    {
        public BaseController<T> Create<T>(IService<T> service) where T : class, IIdentifier
        {
            return new BaseController<T>(service);
        }
    }
}
