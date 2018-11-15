using System;
using System.Reflection;
using micro1.Models.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace micro1.Managers.Broker
{
    public class MessageBrokerFactory
    {
        private readonly IOptions<MessageBrokerSettings> _settings;
        private readonly ILogger<MessageBroker> _logger;

        public MessageBrokerFactory(IOptions<MessageBrokerSettings> settings, ILogger<MessageBroker> logger){
            _settings = settings;
            _logger = logger;
        }

        public MessageBroker Create()
        {
            Type type = Assembly.GetEntryAssembly().GetType(string.Format("micro1.Managers.Broker.{0}Broker", _settings.Value.BrokerType));
            try
            {
                return (MessageBroker)Activator.CreateInstance(type, new object[]{_settings, _logger});
            } 
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}