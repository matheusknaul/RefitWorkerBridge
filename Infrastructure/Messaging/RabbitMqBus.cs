using Application.Interfaces;
using RabbitMQ.Client;

namespace Infrastructure.Messaging
{
    public class RabbitMqBus : IMessageBus, IDisposable
    {
        private IConnection _connection;
        private IChannel _channel;

        private readonly string _hostName;


        public RabbitMqBus(string hostName = "localhost")
        { 
            _hostName = hostName;
        }

        public async Task InitializeAsync()
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            _connection = await factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync<T>(T message, string queueName)
        {
            throw new NotImplementedException();
        }

        public Task SubscribeAsync<T>(string queueName, Func<T, Task> handler)
        {
            throw new NotImplementedException();
        }
    }
}
