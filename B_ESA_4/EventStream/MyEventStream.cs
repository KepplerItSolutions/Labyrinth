using System;

namespace B_ESA_4.EventStream
{
    class MyEventStream
    {
        private static readonly Lazy<EventStream> _instance =
            new Lazy<EventStream>(() => new EventStream());
        public static EventStream Instance => _instance.Value;
    }
}