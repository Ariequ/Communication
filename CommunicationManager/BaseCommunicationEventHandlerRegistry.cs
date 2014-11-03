using System.Collections.Generic;
using Communication;

namespace Communication
{
    public class BaseCommunicationEventHandlerRegistry : ICommunicationEventHandlerRegistry
    {
        private Dictionary<int, CommunicationEventHandler> handlerMap = new Dictionary<int, CommunicationEventHandler>();

        public BaseCommunicationEventHandlerRegistry()
        {
        }

        public void Register(int index, CommunicationEventHandler handler)
        {
            handlerMap.Add(index, handler);
        }

        public void UnRegister(int index)
        {
            handlerMap.Remove(index);
        }

        public CommunicationEventHandler getHandler(int index)
        {
            CommunicationEventHandler handler = null;
            handlerMap.TryGetValue(index, out handler);
            return handler;
        }
    }
}

