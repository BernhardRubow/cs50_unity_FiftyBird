using System;

namespace nvp.events
{
    public class GameEventWrapper
    {
        public event EventHandler GameEventHandler;

        public void TriggerEvent(object sender, EventArgs eventArgs)
        {
            GameEventHandler?.Invoke(sender, eventArgs);
        }
    }
}