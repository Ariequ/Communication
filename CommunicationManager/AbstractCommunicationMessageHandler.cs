using System;

namespace Communication
{
    public abstract class AbstractCommunicationMessageHandler : ICommunicationMassagerHandler
    {
        private CommunicationManager communicationManager;

        public abstract int GetMessageID();

        public abstract void HandleMessage (object message);

        protected void SendMessage(object message, CommunicationEventHandler.OnComplete onComplete = null, 
            CommunicationEventHandler.OnWaiting onWaiting = null, 
            CommunicationEventHandler.OnFail onFail = null)
        {
            communicationManager.SendMessage(message, new CommunicationEventHandler(onComplete, onWaiting, onFail));
        }

        internal void SetCommunicationManager(CommunicationManager communicationManager)
        {
            this.communicationManager = communicationManager;
        }
    }
}

