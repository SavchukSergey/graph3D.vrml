using System;
using Graph3D.Vrml.Tokenizer;

namespace Graph3D.Vrml.Parser {
    public class VrmlParseException : Exception {

        public VrmlParseException() { }

        public TokenizerPosition Position { get; }

        public VrmlParseException(string message, TokenizerPosition position) : base (message) {
            Position = position;
        }

        public VrmlParseException(string message) : base(message) {
        }

        public VrmlParseException(string message, Exception inner) : base(message, inner) {
        }

    }
}
