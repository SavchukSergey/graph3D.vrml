using System;

namespace Graph3D.Vrml.Tokenizer {
    public class MultipartIdentifierState : VrmlTokenizerState {

        public MultipartIdentifierState(TokenizerContext context)
            : base(context) {
        }

        public override VrmlTokenizerState Tick() {
            char ch = context.PeekChar();
            if (tokenizer.IsMultipartIdentifierSeparator(ch)) {
                context.Enqueue(new VRML97Token(context.ReadChar().ToString(), VRML97TokenType.MutipartIdentifierSeparator));
                return new WordState(context);
            } else {
                throw new Exception("Unexpected context");
            }
        }

    }
}
