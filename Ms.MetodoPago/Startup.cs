using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ms.Pago.Aplicacion;
using Ms.Pago.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ms.MetodoPago.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAplicacion(Configuration);
            //services.Configure<DBSettings>(Configuration.GetSection("DBSettings"));
            //services.AddSingleton<IDBSettings>(x => x.GetRequiredService<IOptions<DBSettings>>().Value);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/",
                   async context =>
                   {
                       string color = env.IsDevelopment() ? "Gray" : "Green";
                       await context.Response.WriteAsync($"<h1 style='color:{color};'>[MS.Api] Environment: <a href='/swagger'>{env.EnvironmentName}</a></h1>");
                   });
            });
        }
    }
}
