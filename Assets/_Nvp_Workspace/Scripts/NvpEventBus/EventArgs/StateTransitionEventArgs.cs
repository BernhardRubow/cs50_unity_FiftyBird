using System;

namespace nvp.events
{
    public class StateTransitionEventArgs : EventArgs
    {
        public NvpGameStatesEnum Value;
    }
}