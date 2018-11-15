using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using micro1.Managers.Broker;
using micro1.Models.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace micro1
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
            services.Configure<MessageBrokerSettings>(Configuration.GetSection("MessageBrokerSettings"));
            services.AddTransient<IMessageBroker, MessageBroker>((ctx) => 
            {
                return new MessageBrokerFactory(ctx.GetService<IOptions<MessageBrokerSettings>>(), ctx.GetService<ILogger<MessageBroker>>()).Create();
                //string type = ctx.GetService<IOptions<MessageBrokerSettings>>().Value.Broker;
                //return MessageBroker.CreateInstance(type);
                //return new RabbitMQBroker(ctx.GetService<IOptions<MessageBrokerSettings>>(), ctx.GetService<ILogger<RabbitMQBroker>>());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env/*, ILoggerFactory loggerFactory*/)
        {
            /*
            loggerFactory.AddConsole();
            var logger = loggerFactory.CreateLogger<Startup>();
            logger.LogInformation("Executing Configure()");
            */
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
