using System;
using System.Runtime.Serialization;

namespace B_ESA_4
{
    [Serializable]
    internal class InvalidFormatException : Exception
    {
        public InvalidFormatException()
            :base("Das Format der angegebnene Datei ist nicht korrekt")
        {

        }
        protected InvalidFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}