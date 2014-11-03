using System.Collections.Generic;
using UnityEngine;

namespace Communication
{
    public class CommunicationManager
    {
        private IChannel socketClient;
        private ICommunicationMessageFactory messageFactory;
        private ICommunicationEventHandlerRegistry responseHandlerRegistry;
        private ICommunicationMessageHandlerRegistry messageHandlerRegistry;
        private Queue<IRequestPacket> sendingPacketQueue = new Queue<IRequestPacket>();

        enum COMMUNICATION_STATUS
        {
            SENDING,
            READY_TO_SEND
        }

//        private COMMUNICATION_STATUS  m_Status = COMMUNICATION_STATUS.READY_TO_SEND;

        public CommunicationManager(IChannel channel, ICommunicationMessageFactory messageFactory)
        {
            this.messageFactory = messageFactory;
            this.responseHandlerRegistry = new BaseCommunicationEventHandlerRegistry();
            this.messageHandlerRegistry = new BaseCommunicationMessageHandlerRegistry();

            socketClient = channel;             // = new SocketClient (host, port);
            socketClient.TryConnect();
        }

        public void SendMessage(object message, CommunicationEventHandler callback)
        {
            IRequestPacket request = messageFactory.CreateCommunicationMessage(message);

            responseHandlerRegistry.Register(request.GetOrderID(), callback);

            if (callback != null)
            {
                if (sendingPacketQueue.Count == 0)
                {
                    DoSend(request);
                } 
                else
                {
                    sendingPacketQueue.Enqueue(request);
                }
            }
        }

        public void Update()
        {
            socketClient.HandleReceiveMsgs();

            byte[] data = socketClient.PopHandleMsg();

            if (data != null)
            {
                IResponsePacket response = messageFactory.CreateCommunicationMessage(data);

                ICommunicationMassagerHandler messageHandler = messageHandlerRegistry.GetMessageHandler(response.GetMessageID());

                if (messageHandler != null)
                {
                    messageHandler.HandleMessage(response.GetData());
                }

                int responseOrderID = response.GetOrderID();

                CommunicationEventHandler handler = responseHandlerRegistry.getHandler(responseOrderID);

                if (handler != null)
                {
                    if (handler.CompleteCallBack != null)
                    {
                        handler.CompleteCallBack(response.GetData());
                    }

                    responseHandlerRegistry.UnRegister(responseOrderID);
                }

                if (sendingPacketQueue.Count > 0 && responseOrderID == sendingPacketQueue.Peek().GetOrderID())
                {
                    sendingPacketQueue.Dequeue();
                }
                    
                if (sendingPacketQueue.Count > 0)
                {
                    IRequestPacket request = sendingPacketQueue.Peek();
                    DoSend(request);
                }
            }
        }

        public void RegistMessageHandler(ICommunicationMassagerHandler handler)
        {
            messageHandlerRegistry.AddMessageHandler(handler);
        }

        public void RegistMessageHandler(AbstractCommunicationMessageHandler handler)
        {
            messageHandlerRegistry.AddMessageHandler(handler);

            handler.SetCommunicationManager(this);
        }

        public void UnRegistMessageHandler(ICommunicationMassagerHandler handler)
        {
            messageHandlerRegistry.RemoveMessageHandler(handler);
        }

        public void UnRegistMessageHandler(AbstractCommunicationMessageHandler handler)
        {
            handler.SetCommunicationManager(null);

            messageHandlerRegistry.RemoveMessageHandler(handler);
        }

        private void DoSend(IRequestPacket request)
        {
            socketClient.SendMessage(request.GetData());
        }
    }
}
