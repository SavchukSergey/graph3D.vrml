using System;
using Graph3D.Vrml.Parser;

namespace Graph3D.Vrml {
    public class InvalidVRMLSyntaxException : VrmlParseException {

        public InvalidVRMLSyntaxException() {
        }

        public InvalidVRMLSyntaxException(string message) : base(message) {
        }

        public InvalidVRMLSyntaxException(string message, Exception inner) : base(message, inner) {
        }

    }
}