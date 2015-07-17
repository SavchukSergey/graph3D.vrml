namespace Graph3D.Vrml.Tokenizer {
    public class LineCommentState : VrmlTokenizerState {

        private bool reachedEOL = false;

        public LineCommentState(TokenizerContext context)
            : base(context) {
        }

        protected string text = string.Empty;

        public override VrmlTokenizerState Tick() {
            char ch = context.ReadChar();
            switch (ch) {
                case '\r':
                case '\n':
                    reachedEOL = true;
                    break;
                default:
                    text += ch;
                    break;
            }
            if (tokenizer.IsEOF(ch)) {
                reachedEOL = true;
            }
            if (reachedEOL) {
                return new InitialState(context);
            } else {
                return this;
            }
        }

    }
}
