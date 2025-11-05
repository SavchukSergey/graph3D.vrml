using System;

namespace Graph3D.Vrml.Tokenizer {
    public readonly struct VRML97Token {

        public VRML97Token(ReadOnlyMemory<char> text, VRML97TokenType type) {
            Value = text;
            Type = type;
        }

        public readonly ReadOnlyMemory<char> Value;

        public readonly string Text => new(Value.Span);

        public bool SequenceEqual(ReadOnlySpan<char> other) {
            return Value.Span.SequenceEqual(other);
        }

        public bool StartsWith(ReadOnlySpan<char> other) {
            return Value.Span.StartsWith(other);
        }

        public readonly VRML97TokenType Type;

        public override string ToString() {
            return Type switch {
                VRML97TokenType.Word => "VRML97 Token: " + Text,
                VRML97TokenType.EOF => "VRML97 EOF Token",
                VRML97TokenType.OpenBrace => "VRML97 OpenBrace ('{') Token",
                VRML97TokenType.CloseBrace => "VRML97 CloseBrace ('}') Token",
                VRML97TokenType.OpenBracket => "VRML97 OpenBracket ('[') Token",
                VRML97TokenType.CloseBracket => "VRML97 CloseBracket (']') Token",
                _ => throw new NotSupportedException(),
            };
        }

    }
}
