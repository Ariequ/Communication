using System;

namespace Communication
{
    public interface ICommunicationPacket
    {
        int GetMessageID ();

        int GetOrderID ();
    }
}

