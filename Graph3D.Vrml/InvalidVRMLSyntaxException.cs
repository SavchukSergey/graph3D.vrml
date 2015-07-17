using System;
using Graph3D.Vrml.Parser;

namespace Graph3D.Vrml {

    [Serializable]
    public class InvalidVRMLSyntaxException : VrmlParseException
    {
        public InvalidVRMLSyntaxException() { }
        public InvalidVRMLSyntaxException(string message) : base(message) { }
        public InvalidVRMLSyntaxException(string message, Exception inner) : base(message, inner) { }
        protected InvalidVRMLSyntaxException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
