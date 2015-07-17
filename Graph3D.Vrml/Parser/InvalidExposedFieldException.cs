using System;

namespace Graph3D.Vrml.Parser {
    [Serializable]
    public class InvalidExposedFieldException : VrmlParseException {
        
        public InvalidExposedFieldException() { }
        
        public InvalidExposedFieldException(string message) : base(message) { }
        
        public InvalidExposedFieldException(string message, Exception inner) : base(message, inner) { }
        
        protected InvalidExposedFieldException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

    }
}
