namespace ProducerApplication.Services
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);

    }
}
