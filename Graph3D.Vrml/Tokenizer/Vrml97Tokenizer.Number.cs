using System;

namespace Graph3D.Vrml.Tokenizer {
    public partial class Vrml97Tokenizer {

        public VRML97Token ConsumeNumberToken() {
            var startIndex = context.Source.Index;

            var ch = context.PeekChar();
            var ch2 = context.PeekChar(1);
            if (ch == '0' && ch2 == 'x') {
                return ConsumeHexNumberToken();
            }

            if (ch == '+' || ch == '-') {
                ch = context.ReadAndPeek();
            }

            var fractionStarted = false;
            if (ch == '.') {
                ch = context.ReadAndPeek();
                fractionStarted = true;
            }

            while (char.IsDigit(ch)) {
                ch = context.ReadAndPeek();
            }

            if (ch == '.') {
                if (fractionStarted) {
                    throw new InvalidVRMLSyntaxException("Unexpected character", context.Position);
                }
                ch = context.ReadAndPeek();

                while (char.IsDigit(ch)) {
                    ch = context.ReadAndPeek();
                }
            }

            if (ch == 'e' || ch == 'E') {
                ch = context.ReadAndPeek();

                if (ch == '+' || ch == '-') {
                    ch = context.ReadAndPeek();
                }
                while (char.IsDigit(ch)) {
                    ch = context.ReadAndPeek();
                }
            }

            return new VRML97Token(context.Source.Content.AsMemory(startIndex, context.Source.Index - startIndex), VRML97TokenType.Word);
        }

        private VRML97Token ConsumeHexNumberToken() {
            var startIndex = context.Source.Index;
            context.RequireChar('0');
            context.RequireChar('x');

            while (!context.Source.IsEOF) {
                var ch = context.Source.PeekChar();
                if (char.IsAsciiHexDigit(ch)) {
                    context.Source.ReadChar();
                    continue;
                }
                break;
            }

            return new VRML97Token(context.Source.Content.AsMemory(startIndex, context.Source.Index - startIndex), VRML97TokenType.Word);
        }
    }
}