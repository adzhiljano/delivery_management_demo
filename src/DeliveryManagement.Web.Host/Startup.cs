using Autofac;
using Autofac.Extensions.DependencyInjection;
using DeliveryManagement.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace DeliveryManagement.Web.Host
{
    public class Startup
    {

        public static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
#if DEBUG
            Formatting = Formatting.Indented,
#else
            Formatting = Formatting.None,
#endif
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Include,
            DefaultValueHandling = DefaultValueHandling.Include,
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            //since rc2 the default ContractResolver is CamelCasePropertyNamesContractResolver
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter>()
            {
                new StringEnumConverter { CamelCaseText = false }
            }
        };
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.Formatting = JsonSerializerSettings.Formatting;
                opt.SerializerSettings.ReferenceLoopHandling = JsonSerializerSettings.ReferenceLoopHandling;
                opt.SerializerSettings.NullValueHandling = JsonSerializerSettings.NullValueHandling;
                opt.SerializerSettings.DefaultValueHandling = JsonSerializerSettings.DefaultValueHandling;
                opt.SerializerSettings.DateFormatHandling = JsonSerializerSettings.DateFormatHandling;
                opt.SerializerSettings.ContractResolver = JsonSerializerSettings.ContractResolver;
                opt.SerializerSettings.Converters = JsonSerializerSettings.Converters;
            });

            // Application settings
            services.AddOptions();

            services.Configure<DomainAppSettings>(Configuration.GetSection("Domain"));

            // Autofac
            var builder = new ContainerBuilder();

            builder.RegisterModule(new DomainModule());

            builder.Populate(services);

            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
                ContentTypeProvider = new ContentTypeProvider(),
                ServeUnknownFileTypes = false,
                OnPrepareResponse = sfrc =>
                {
                    sfrc.Context.Response.Headers.Add("Cache-Control", new[] { "no-cache", "no-store", "must-revalidate" });
                    sfrc.Context.Response.Headers.Add("Pragma", new[] { "no-cache" });
                    sfrc.Context.Response.Headers.Add("Expires", new[] { "0" });
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
