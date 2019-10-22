using System;

namespace nvp.events
{
    public class GenericEventArgs : EventArgs
    {
        private object _value;


        public GenericEventArgs(object value)
        {
            _value = value;
        }

        public T GetValue<T>()
        {
            return (T)_value;
        }
    }
}

