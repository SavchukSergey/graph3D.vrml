using System;

namespace Graph3D.Vrml.Parser
{
    [Serializable]
    public class InvalidEventOutException : VrmlParseException
    {
        public InvalidEventOutException() { }
        
        public InvalidEventOutException(string message) : base(message) { }
        
        public InvalidEventOutException(string message, Exception inner) : base(message, inner) { }
        
        protected InvalidEventOutException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

    }
}
