using System;

namespace Graph3D.Vrml.Tokenizer {
    public class PunctuationState : VrmlTokenizerState {
        
        public PunctuationState(TokenizerContext context)
            : base(context) {
        }

        public override VrmlTokenizerState Tick() {
            char ch = context.ReadChar();
            if (tokenizer.IsOpenBrace(ch)) {
                context.Enqueue(new VRML97Token(ch.ToString(), VRML97TokenType.OpenBrace));
                return new InitialState(context);
            }
            if (tokenizer.IsCloseBrace(ch)) {
                context.Enqueue(new VRML97Token(ch.ToString(), VRML97TokenType.CloseBrace));
                return new InitialState(context);
            }
            if (tokenizer.IsOpenBracket(ch)) {
                context.Enqueue(new VRML97Token(ch.ToString(), VRML97TokenType.OpenBracket));
                return new InitialState(context);
            }
            if (tokenizer.IsCloseBracket(ch)) {
                context.Enqueue(new VRML97Token(ch.ToString(), VRML97TokenType.CloseBracket));
                return new InitialState(context);
            }
            throw new Exception("Unexpected character");
        }

    }
}
