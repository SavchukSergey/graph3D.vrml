using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Tokenizer;

namespace Graph3D.Vrml {
    public class InvalidVRMLSyntaxException : VrmlParseException {

        public InvalidVRMLSyntaxException(string message, TokenizerPosition position) : base (message, position) {
        }

        public InvalidVRMLSyntaxException(string message) : base(message) {
        }

    }
}