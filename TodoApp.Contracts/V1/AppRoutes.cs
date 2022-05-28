using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Contracts.V1
{
    public class AppRoutes
    {
        private const string root = "api";
        private const string version = "v1";
        private const string Base = root + "/" + version;

        public static class Item
        {
            public const string GetAll = Base + "/items";
            public const string Get = Base + "/items/{id}";
            public const string Create = Base + "/items";
            public const string Update = Base + "/items/{id}";
            public const string Delete = Base + "/items/{id}";
        }
    }
}
