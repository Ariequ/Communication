namespace Communication
{
	public interface ICommunicationMassagerHandler
	{
        int GetMessageID();

        void HandleMessage (object message);
	}
}

