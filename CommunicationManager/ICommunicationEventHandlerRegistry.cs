namespace Communication
{
	public interface ICommunicationEventHandlerRegistry
	{
		void Register (int index, CommunicationEventHandler handler);
		void UnRegister (int index);
		CommunicationEventHandler getHandler (int index);
	}
}

