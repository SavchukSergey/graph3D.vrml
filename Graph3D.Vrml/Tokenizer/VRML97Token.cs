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
            switch (type) {
                case VRML97TokenType.Word:
                    return "VRML97 Token: " + text;
                case VRML97TokenType.EOF:
                    return "VRML97 EOF Token";
                case VRML97TokenType.OpenBrace:
                    return "VRML97 OpenBrace ('{') Token";
                case VRML97TokenType.CloseBrace:
                    return "VRML97 CloseBrace ('}') Token";
                case VRML97TokenType.OpenBracket:
                    return "VRML97 OpenBracket ('[') Token";
                case VRML97TokenType.CloseBracket:
                    return "VRML97 CloseBracket (']') Token";

                default:
                    throw new NotSupportedException();
            }
        }

    }
}
