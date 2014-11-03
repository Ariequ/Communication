using System.Collections.Generic;

namespace Communication
{
    public class BaseCommunicationMessageHandlerRegistry : ICommunicationMessageHandlerRegistry
    {
        private Dictionary<int, ICommunicationMassagerHandler> handlerMap = new Dictionary<int, ICommunicationMassagerHandler>();

        public void AddMessageHandler(ICommunicationMassagerHandler handler)
        {
            if (!handlerMap.ContainsKey(handler.GetMessageID()))
            {
                handlerMap.Add(handler.GetMessageID(), handler);
            }
        }

        public void RemoveMessageHandler(ICommunicationMassagerHandler handler)
        {
            const int INVALID_MID = -1;

            int messageID = INVALID_MID;

            foreach (KeyValuePair<int, ICommunicationMassagerHandler> kvPair in handlerMap)
            {
                if (ReferenceEquals(kvPair.Value, handler))
                {
                    messageID = kvPair.Key;

                    break;
                }
            }

            if (messageID != INVALID_MID)
            {
                handlerMap.Remove(messageID);
            }
        }

        public ICommunicationMassagerHandler GetMessageHandler(int messageID)
        {
            ICommunicationMassagerHandler handler = null;
            handlerMap.TryGetValue(messageID, out handler);
            return handler;
        }
    }
}