using System;

namespace Graph3D.Vrml.Tokenizer {
    public partial class Vrml97Tokenizer {

        public VRML97Token ConsumeStringConstantToken() {
            var quoteChar = context.ReadChar();
            var startIndex = context.Source.Index;

            while (!context.Source.IsEOF) {
                var ch = context.ReadChar();
                if (IsQuote(ch)) {
                    var endIndex = context.Source.Index;
                    var rawText = context.Source.Content.AsMemory(startIndex, endIndex - startIndex - 1);
                    return new VRML97Token(Unescape(rawText), VRML97TokenType.Word);
                }

                if (IsEscapeSymbol(ch)) {
                    ch = context.ReadChar();
                    if (ch != quoteChar && !IsEscapeSymbol(ch)) {
                        throw new InvalidVRMLSyntaxException($"Unexpected escape symbol {ch}", Position);
                    }
                }
            }

            throw new InvalidVRMLSyntaxException($"Unqouted string", Position);
        }

        private static ReadOnlyMemory<char> Unescape(ReadOnlyMemory<char> source) {
            var dirty = false;
            Span<char> res = stackalloc char[source.Length];
            var resIndex = 0;
            for (var i = 0; i < source.Length; i++) {
                var ch = source.Span[i];
                if (IsEscapeSymbol(ch)) {
                    ch = source.Span[i++]; //either quote or escape symbol itself
                    dirty = true;
                }
                res[resIndex++] = ch;
            }
            if (dirty) {
                return new string(res[..resIndex]).AsMemory();
            }

            return source;
        }
    }
}