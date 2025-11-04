using System;

namespace Graph3D.Vrml.Tokenizer {
    public class StringConstantState : VrmlTokenizerState {

        public StringConstantState(TokenizerContext context)
            : base(context) {
        }

        private string state = "";
        private string text = "";
        private char quote;

        public override VrmlTokenizerState Tick() {
            var ch = context.ReadChar();
            switch (state) {
                case "":
                    if (tokenizer.IsQuote(ch)) {
                        quote = ch;
                        state = "q";
                    } else {
                        throw new Exception("Unexpected state");
                    }
                    break;
                case "q":
                    if (tokenizer.IsQuote(ch)) {
                        context.Enqueue(new VRML97Token(text, VRML97TokenType.Word));
                        return new InitialState(context);
                    }
                    if (tokenizer.IsEscapeSymbol(ch)) {
                        state = "e";
                        break;
                    }
                    text += ch;
                    break;
                case "e":
                    if (ch == quote) {
                        text += ch;
                        state = "q";
                        break;
                    }
                    if (tokenizer.IsEscapeSymbol(ch)) {
                        text += ch;
                        state = "q";
                        break;
                    }
                    throw new InvalidVRMLSyntaxException("Unexpected escape symbol " + ch.ToString());
            }
            return this;
        }

    }

}
