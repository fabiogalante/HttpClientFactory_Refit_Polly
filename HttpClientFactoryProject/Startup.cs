using HttpClientFactoryProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Refit;
using System;
using HttpClientFactoryProject.Configuration;

namespace HttpClientFactoryProject
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.Configure<ApiConfig>(Configuration.GetSection(nameof(ApiConfig)));

            //Singleton
           // services.AddSingleton<IApiConfig>(x => x.GetRequiredService<IOptions<ApiConfig>>().Value);



            //Criar uma politica de retry (tente 3x, com timeout de 3 segundos)
            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                 .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));
            //.WaitAndRetryAsync(new[]
            //{
            //    TimeSpan.FromSeconds(1),
            //    TimeSpan.FromSeconds(2),
            //    TimeSpan.FromSeconds(4),
            //    TimeSpan.FromSeconds(8),
            //    TimeSpan.FromSeconds(15),
            //    TimeSpan.FromSeconds(30)
            //});


            // https://github.com/App-vNext/Polly
            // https://github.com/App-vNext/Polly/wiki/Retry


            //Registrar httpclient
            //services.AddHttpClient<IClienteService, ClienteService>(b =>
            //    b.BaseAddress = new Uri(Configuration["ApiConfig:BaseUrl"]))
            //    .AddPolicyHandler(retryPolicy);

            services.AddRefitClient<IClienteService>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(Configuration["ApiConfig:BaseUrl"]);
                })
                .AddPolicyHandler(retryPolicy);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
