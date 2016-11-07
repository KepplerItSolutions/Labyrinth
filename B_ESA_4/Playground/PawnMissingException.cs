using System;
using System.Runtime.Serialization;

namespace B_ESA_4.Playground
{
    [Serializable]
    internal class PawnMissingException : Exception
    {
        public PawnMissingException()
            : base("Das Labyrinth enthält keinen Spieler")
        {
        }        

        protected PawnMissingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}