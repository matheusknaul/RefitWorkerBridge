﻿namespace Application.Interfaces
{
    public interface IMessageBus
    {
        Task PublishAsync<T>(T message, string queueName);
        Task SubscribeAsync<T>(string queueName, Func<T, Task> handler);
    }
}
