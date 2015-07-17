using System;

namespace Graph3D.Vrml.Parser {

    [Serializable]
    public class InvalidEventInException : VrmlParseException {
        public InvalidEventInException() { }
        public InvalidEventInException(string message) : base(message) { }
        public InvalidEventInException(string message, Exception inner) : base(message, inner) { }
        protected InvalidEventInException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
