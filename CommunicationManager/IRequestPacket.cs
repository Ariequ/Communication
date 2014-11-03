using System;

namespace Communication
{
    public interface IRequestPacket : ICommunicationPacket
    {
        byte[] GetData ();
    }
}
    