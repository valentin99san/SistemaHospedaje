using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDA.Ms.Gateway.Aplicacion.Common;

namespace TDA.Ms.Gateway.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {
            // Client Settings
            var msSettings = new ClientSettings();
            configuration.Bind(nameof(ClientSettings), msSettings);

            #region Cliente MsProductos

            services.AddHttpClient("MsProductos", client =>
            {
                client.BaseAddress = new Uri(msSettings.ProductosUrl);
            });

            services.AddTransient<ProductosClient.IClient, ProductosClient.Client>();

            #endregion

            #region Cliente MsClientes

            services.AddHttpClient("MsClientes", client =>
            {
                client.BaseAddress = new Uri(msSettings.ClientesUrl);
            });

            services.AddScoped<ClientesClient.IClient, ClientesClient.Client>();

            #endregion

            return services;
        }

    }
}
