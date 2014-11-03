namespace Communication
{
    public interface IChannel
    {
        void TryConnect();
        void SendMessage(byte[] data);
        void HandleReceiveMsgs();
        byte[] PopHandleMsg();
    }
}

