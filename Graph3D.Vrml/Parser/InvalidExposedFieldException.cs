using System;

namespace Graph3D.Vrml.Parser {
    public class InvalidExposedFieldException : VrmlParseException {
        
        public InvalidExposedFieldException() {
        }
        
        public InvalidExposedFieldException(string message) : base(message) {
        }
        
        public InvalidExposedFieldException(string message, Exception inner) : base(message, inner) {
        }
        
    }
}
