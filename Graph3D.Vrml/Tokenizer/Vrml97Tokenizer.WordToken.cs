using System;

namespace Graph3D.Vrml.Tokenizer {
    public partial class Vrml97Tokenizer {

        public VRML97Token ConsumeWordToken() {
            var startIndex = context.Source.Index;

            var ch = context.PeekChar();
            if (IsIdFirstChar(ch)) {
                ch = context.ReadAndPeek();
            } else {
                throw new InvalidVRMLSyntaxException("Unexpected char", context.Position);
            }

            while (IsIdRestChar(ch)) {
                ch = context.ReadAndPeek();
            }

            var text = context.Source.Content.AsMemory(startIndex, context.Source.Index - startIndex);
            return new VRML97Token(text, VRML97TokenType.Word);
        }

    }
}