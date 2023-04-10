using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Framework.MessageBrokers
{
    public interface IRabbitMqPublisher
    {
        Task<bool> SendMessageAsync<T>(T message);
        Task<bool> SendMessagesAsync<T>(List<T> messages);
    }
}
