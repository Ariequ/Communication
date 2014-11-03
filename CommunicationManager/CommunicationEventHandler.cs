namespace Communication
{
	public class CommunicationEventHandler
	{
        public delegate void OnComplete (object message);

		public delegate void OnWaiting ();

		public delegate void OnFail ();

		public OnComplete CompleteCallBack;
		public OnFail FailCallBack;
		public OnWaiting WaitingCallBack;

		public CommunicationEventHandler (OnComplete onComplete = null, OnWaiting onWaiting = null, OnFail onFail = null)
		{
			this.CompleteCallBack = onComplete;
			this.FailCallBack = onFail;
			this.WaitingCallBack = onWaiting;
		}
	}
}

