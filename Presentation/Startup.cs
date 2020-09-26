using System.IO;
using System.Reflection;
using System.ServiceModel;
using log4net;
using log4net.Config;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Presentation.Controllers;
using SoapCore;
using Application.AddNumbers;

namespace Presentation
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
            services.AddSoapCore();

            services.TryAddSingleton<IMediator, Mediator>();


            services.TryAddSingleton<IAddNumberController, AddNumberController>();

            services.TryAddSingleton<IAddNumbersService, AddNumbersService>();
            services.TryAddSingleton<IAddNumbersRepository, AddNumbersRepository>();

            services.AddControllers();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IRequestHandler<GetAddNumberQuery, GetAddNumberDto>, GetAddNumberQueryHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            loggerFactory.AddLog4Net();

            ConfigureLogging();

            app.UseHttpsRedirection();

            app.UseSoapEndpoint<IAddNumberController>("/maths.asmx", new BasicHttpBinding());

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void ConfigureLogging()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}