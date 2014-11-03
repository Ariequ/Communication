using System;

namespace Communication
{
    public interface ICommunicationMessageFactory
    {
        IRequestPacket CreateCommunicationMessage (object message);

        IResponsePacket CreateCommunicationMessage (byte[] message);
    }
}

