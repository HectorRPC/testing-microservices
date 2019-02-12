using System.Text;
using micro1.Models.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace micro1.Managers.Broker
{
    public abstract class MessageBroker: IMessageBroker
    {
        internal ILogger _logger;
        internal MessageBrokerSettings _settings;
        public MessageBroker(IOptions<MessageBrokerSettings> config, ILogger<MessageBroker> logger){
            _logger = logger;
            _settings = config.Value;
        }

        public abstract void PublishMessage(string queue, byte[] body);
    }
}