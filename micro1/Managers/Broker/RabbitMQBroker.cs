using System.Text;
using micro1.Models.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace micro1.Managers.Broker
{
    public class RabbitMQBroker: MessageBroker
    {
        public RabbitMQBroker(IOptions<MessageBrokerSettings> config, ILogger<MessageBroker> logger):base(config, logger){
            
        }

        public override void PublishMessage(string queue, byte[] body)
        {
            var factory = new ConnectionFactory() { HostName = _settings.HostName };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                //string message = "Hello World!";
                //var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                    routingKey: "hello",
                                    basicProperties: null,
                                    body: body);
                _logger.LogInformation(" [x] Sent {0}", queue);
            }
        }

        public void send(){
            
        }
    }
}