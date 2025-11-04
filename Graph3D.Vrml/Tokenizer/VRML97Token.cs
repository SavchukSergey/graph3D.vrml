using System;
using System.Diagnostics;

namespace Graph3D.Vrml.Tokenizer {
    public class VRML97Token {

        public VRML97Token(string text, VRML97TokenType type) {
            this.text = text;
            this.type = type;
        }

        private readonly string text;
        public string Text {
            [DebuggerStepThrough]
            get { return text; }
        }

        private readonly VRML97TokenType type;
        public VRML97TokenType Type {
            [DebuggerStepThrough]
            get { return type; }
        }

        public override string ToString() {
            return type switch {
                VRML97TokenType.Word => "VRML97 Token: " + text,
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
