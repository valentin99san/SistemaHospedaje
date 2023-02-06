namespace Ms.Alquiler.API.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteAlquiler
        {
            // Read
            public const string GetAll = Base + "/alquiler/all";
            public const string GetById = Base + "/alquiler/{id}";

            // Write
            public const string Create = Base + "/alquiler/create";
            public const string Update = Base + "/alquiler/update";
            public const string Delete = Base + "/alquiler/delete";
            
        }

        
    }
}
