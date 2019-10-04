using System.Collections.Generic;

namespace nvp.events
{
    public class NvpEventBus
    {
        private static readonly Dictionary<GameEvents, GameEventWrapper> EventHandlers;

        static NvpEventBus()
        {
            EventHandlers = new Dictionary<GameEvents, GameEventWrapper>();
        }

        public static GameEventWrapper Events(GameEvents eventName)
        {
            if (!EventHandlers.ContainsKey(eventName))
                EventHandlers[eventName] = new GameEventWrapper();

            return EventHandlers[eventName];
        }
    }

    // Sample EventArgs
}