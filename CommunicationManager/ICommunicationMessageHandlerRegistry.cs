namespace Communication
{
    public interface ICommunicationMessageHandlerRegistry
    {
        void AddMessageHandler(ICommunicationMassagerHandler handler);

        void RemoveMessageHandler(ICommunicationMassagerHandler handler);

        ICommunicationMassagerHandler GetMessageHandler(int messageID);
    }
}

