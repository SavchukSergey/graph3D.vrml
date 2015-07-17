using System;

namespace Graph3D.Vrml.Parser {
    [global::System.Serializable]
    public class VrmlParseException : Exception {

        public VrmlParseException() { }

        public VrmlParseException(string message) : base(message) { }
        
        public VrmlParseException(string message, Exception inner) : base(message, inner) { }
        
        protected VrmlParseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

    }
}
