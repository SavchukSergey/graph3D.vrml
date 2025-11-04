using System;

namespace Graph3D.Vrml.Tokenizer {
    public readonly struct VRML97Token {

        public VRML97Token(string text, VRML97TokenType type) {
            Text = text;
            Type = type;
        }

        public readonly string Text;

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
