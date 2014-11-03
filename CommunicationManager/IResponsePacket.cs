using System;

namespace Communication
{
    public interface IResponsePacket : ICommunicationPacket
    {
        object GetData ();
    }
}
    