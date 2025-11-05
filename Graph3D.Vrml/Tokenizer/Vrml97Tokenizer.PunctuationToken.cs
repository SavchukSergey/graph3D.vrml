using System;

namespace Graph3D.Vrml.Tokenizer {
    public partial class Vrml97Tokenizer {

        public VRML97Token ConsumePunctuationToken() {
            var ch = context.ReadChar();
            if (IsOpenBrace(ch)) {
                return new VRML97Token("{".AsMemory(), VRML97TokenType.OpenBrace);
            }
            if (IsCloseBrace(ch)) {
                return new VRML97Token("}".AsMemory(), VRML97TokenType.CloseBrace);
            }
            if (IsOpenBracket(ch)) {
                return new VRML97Token("[".AsMemory(), VRML97TokenType.OpenBracket);
            }
            if (IsCloseBracket(ch)) {
                return new VRML97Token("]".AsMemory(), VRML97TokenType.CloseBracket);
            }
            throw new InvalidVRMLSyntaxException($"Unexpected character {ch}", Position);
        }

    }
}