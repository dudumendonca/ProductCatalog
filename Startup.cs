using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductCatalog.Data;

namespace ProductCatalog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // AddScoped = Cria um item por requisição se não existir abre uma nova instancia
            // AddTransient = Cria varios itens
            services.AddScoped<StoreDataContext, StoreDataContext>();
            // services.AddTransient<StoreDataContext, StoreDataContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            
            app.UseRouting();
            app.UseEndpoints(builder => builder.MapControllers());
        }
    }
}
