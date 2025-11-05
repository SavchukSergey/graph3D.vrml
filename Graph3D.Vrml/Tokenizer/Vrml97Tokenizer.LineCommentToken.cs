using System;

namespace Graph3D.Vrml.Tokenizer {
    public partial class Vrml97Tokenizer {

        public VRML97Token ConsumeLineCommentToken() {
            var start = context.Source.Index;
            context.RequireChar('#');

            while (!context.Source.IsEOF) {
                var ch = context.ReadChar();
                if (ch == '\r') {
                    if (context.PeekChar() == '\n') {
                        context.ReadChar();
                    }
                    break;
                }
                if (ch == '\n') {
                    break;
                }
            }

            return new VRML97Token(context.Source.Content.AsMemory(start, context.Source.Index - start), VRML97TokenType.Word);
        }

    }
}