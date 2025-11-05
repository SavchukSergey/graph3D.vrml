using System;

namespace Graph3D.Vrml.Tokenizer {
    public static class TokensSourceExt {

        public static VRML97Token ConsumeStringConstantToken(this TokensSource source) {
            var quoteChar = source.ReadChar();
            var startIndex = source.Index;

            while (!source.IsEOF) {
                var ch = source.ReadChar();
                if (Vrml97Tokenizer.IsQuote(ch)) {
                    var endIndex = source.Index;
                    var rawText = source.Content.AsMemory(startIndex, endIndex - startIndex - 1);
                    return new VRML97Token(Unescape(rawText), VRML97TokenType.Word);
                }

                if (Vrml97Tokenizer.IsEscapeSymbol(ch)) {
                    ch = source.ReadChar();
                    if (ch != quoteChar && !Vrml97Tokenizer.IsEscapeSymbol(ch)) {
                        throw new InvalidVRMLSyntaxException($"Unexpected escape symbol {ch}", source.Position);
                    }
                }
            }

            throw new InvalidVRMLSyntaxException($"Unquoted string", source.Position);
        }

        private static ReadOnlyMemory<char> Unescape(ReadOnlyMemory<char> source) {
            var dirty = false;
            Span<char> res = stackalloc char[source.Length];
            var resIndex = 0;
            for (var i = 0; i < source.Length; i++) {
                var ch = source.Span[i];
                if (Vrml97Tokenizer.IsEscapeSymbol(ch)) {
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