using System;

namespace Graph3D.Vrml.Tokenizer {
    public class WordState : VrmlTokenizerState {
        
        public WordState(TokenizerContext context)
            : base(context) {
        }

        private string text;
        
        public override VrmlTokenizerState Tick() {
            char ch = context.PeekChar();
            if (string.IsNullOrEmpty(text)) {
                if (tokenizer.IsIdFirstChar(ch)) {
                    text += context.ReadChar();
                    return this;
                } else {
                    throw new Exception("Unexpected char");
                }
            } else {
                if (tokenizer.IsIdRestChar(ch)) {
                    text += context.ReadChar();
                    return this;
                } else {
                    context.Enqueue(new VRML97Token(text, VRML97TokenType.Word));
                    if (tokenizer.IsMultipartIdentifierSeparator(ch)) {
                        return new MultipartIdentifierState(context);
                    } else {
                        return new InitialState(context);
                    }
                }
            }
        }

    }

}
