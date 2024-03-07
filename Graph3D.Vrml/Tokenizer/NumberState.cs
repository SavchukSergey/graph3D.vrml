using System;

namespace Graph3D.Vrml.Tokenizer {
    public class NumberState : VrmlTokenizerState {

        public NumberState(TokenizerContext context)
            : base(context) {
        }

        private string state = "";
        private string text = "";

        public override VrmlTokenizerState Tick() {
            char ch = context.PeekChar();
            //sndnesn - Sign, Number, Dot, Number, Exponenta, Sign, Number
            switch (state) {
                case "":
                    if (ch == '0') {
                        text += context.ReadChar();
                        state = "0";
                    } else if (ch == '+' || ch == '-') {
                        text += context.ReadChar();
                        state = "s";
                    } else if (char.IsDigit(ch)) {
                        text += context.ReadChar();
                        state = "sn";
                    } else if (ch == '.') {
                        text += context.ReadChar();
                        state = "snd";
                    } else {
                        throw new Exception("Unexpected character");
                    }
                    break;
                case "0":
                    if (ch == 'x') {
                        text += context.ReadChar();
                        state = "0x";
                    } else {
                        state = "sn";
                    }
                    break;
                case "s":
                    if (char.IsDigit(ch)) {
                        text += context.ReadChar();
                        state = "sn";
                    } else if (ch == '.') {
                        text += context.ReadChar();
                        state = "snd";
                    } else {
                        throw new Exception("Unexpected character");
                    }
                    break;
                case "sn":
                    if (char.IsDigit(ch)) {
                        text += context.ReadChar();
                        state = "sn";
                    } else if (ch == '.') {
                        text += context.ReadChar();
                        state = "snd";
                    } else if (tokenizer.IsWhiteSpace(ch) || tokenizer.IsPunctuation(ch)) {
                        context.Enqueue(new VRML97Token(text, VRML97TokenType.Word));
                        return new InitialState(context);
                    } else if (ch == 'e' || ch == 'E') {
                        text += context.ReadChar();
                        state = "sndne";
                    } else {
                        throw new TokenizerException("Invalid Number");
                    }
                    break;
                case "snd":
                    if (char.IsDigit(ch)) {
                        text += context.ReadChar();
                        state = "sndn";
                    } else if (ch == 'e' || ch == 'E') {
                        text += context.ReadChar();
                        state = "sndne";
                    } else if (tokenizer.IsWhiteSpace(ch) || tokenizer.IsPunctuation(ch)) {
                        context.Enqueue(new VRML97Token(text, VRML97TokenType.Word));
                        return new InitialState(context);
                    } else {
                        throw new TokenizerException("Invalid Number");
                    }
                    break;
                case "sndn":
                    if (char.IsDigit(ch)) {
                        text += context.ReadChar();
                        state = "sndn";
                    } else if (ch == 'e' || ch == 'E') {
                        text += context.ReadChar();
                        state = "sndne";
                    } else if (tokenizer.IsWhiteSpace(ch) || tokenizer.IsPunctuation(ch)) {
                        context.Enqueue(new VRML97Token(text, VRML97TokenType.Word));
                        return new InitialState(context);
                    } else {
                        throw new TokenizerException("Invalid Number");
                    }
                    break;
                case "sndne":
                    if (ch == '+' || ch == '-') {
                        text += context.ReadChar();
                        state = "sndnes";
                    } else if (char.IsDigit(ch)) {
                        text += context.ReadChar();
                        state = "sndnesn";
                    } else {
                        throw new Exception("Unexpected character");
                    }
                    break;
                case "sndnes":
                    if (char.IsDigit(ch)) {
                        text += context.ReadChar();
                        state = "sndnesn";
                    } else {
                        throw new Exception("Unexpected character");
                    }
                    break;
                case "sndnesn":
                    if (char.IsDigit(ch)) {
                        text += context.ReadChar();
                        state = "sndnesn";
                    } else if (tokenizer.IsWhiteSpace(ch) || tokenizer.IsPunctuation(ch)) {
                        context.Enqueue(new VRML97Token(text, VRML97TokenType.Word));
                        return new InitialState(context);
                    } else {
                        throw new Exception("Unexpected character");
                    }
                    break;
            }
            return this;
        }

    }
}
