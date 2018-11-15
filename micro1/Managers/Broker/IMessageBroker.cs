namespace micro1.Managers.Broker
{
    public interface IMessageBroker
    {
        void PublishMessage(string queue, byte[] body);
    }
}