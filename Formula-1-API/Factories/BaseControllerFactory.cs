using System;
using Formula_1_API.Controllers;
using Formula_1_API.Models;
using Formula_1_API.Services;

namespace Formula_1_API.Factories
{
    public class BaseControllerFactory
    {
        public BaseController<T> Create<T>(IService<T> service) where T : class, IIdentifier
        {
            return new BaseController<T>(service);
        }
    }
}
