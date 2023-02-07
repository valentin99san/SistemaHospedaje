namespace Ms.Cliente.API.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteCliente
        {
            //Read
            public const string GetAll = Base + "/habitacion/all";
            public const string GetById = Base + "/habitacion/{id}";

            //Write
            public const string Create = Base + "/habitacion/create";
            public const string Update = Base + "/habitacion/update";
            public const string Delete = Base + "/habitacion/delete";
        }

        
    }

}
