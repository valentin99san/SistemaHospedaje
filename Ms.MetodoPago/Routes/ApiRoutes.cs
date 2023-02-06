namespace Ms.MetodoPago.API.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteHabitacion
        {
            //Read
            public const string GetAll = Base + "/pagos/all";
            public const string GetById = Base + "/pagos/{id}";

            //Write
            public const string Create = Base + "/pagos/create";
            public const string Update = Base + "/pagos/update";
            public const string Delete = Base + "/pagos/delete";
        }
    }
}
