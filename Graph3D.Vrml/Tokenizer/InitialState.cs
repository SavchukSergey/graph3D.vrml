using System;

namespace Graph3D.Vrml.Tokenizer {
    public class InitialState : VrmlTokenizerState {
        public InitialState(TokenizerContext context)
            : base(context) {
        }

        public override VrmlTokenizerState Tick() {
            char ch = context.PeekChar();
            if (tokenizer.IsWhiteSpace(ch)) {
                context.ReadChar();
                return this;
            }
            if (tokenizer.IsEOF(ch)) {
                context.Enqueue(new VRML97Token("", VRML97TokenType.EOF));
                return this;
            }
            if (tokenizer.IsLineComment(ch)) {
                return new LineCommentState(context);
            }
            if (tokenizer.IsPunctuation(ch)) {
                return new PunctuationState(context);
            }
            if (tokenizer.IsQuote(ch)) {
                return new StringConstantState(context);
            }
            if (tokenizer.IsIdFirstChar(ch)) {
                return new WordState(context);
            }
            if (Vrml97Tokenizer.IsNumberFirstChar(ch)) {
                return new NumberState(context);
            }
            throw new Exception("Unexpected symbol");
        }
    }

}
