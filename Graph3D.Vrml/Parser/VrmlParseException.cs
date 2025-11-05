using System;
using Graph3D.Vrml.Tokenizer;

namespace Graph3D.Vrml.Parser {
    public class VrmlParseException : Exception {

        public VrmlParseException() { }

        public TokenPosition Position { get; }

        public VrmlParseException(string message, TokenPosition position) : base (message) {
            Position = position;
        }

        public VrmlParseException(string message) : base(message) {
        }
    }
}
