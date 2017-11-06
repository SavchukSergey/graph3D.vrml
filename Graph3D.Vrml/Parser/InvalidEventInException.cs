using System;

namespace Graph3D.Vrml.Parser {
    public class InvalidEventInException : VrmlParseException {

        public InvalidEventInException() {
        }

        public InvalidEventInException(string message) : base(message) {
        }

        public InvalidEventInException(string message, Exception inner) : base(message, inner) {
        }

    }
}
