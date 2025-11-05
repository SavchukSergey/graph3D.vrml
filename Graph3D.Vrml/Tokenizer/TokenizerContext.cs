using System.Collections.Generic;
using System.Diagnostics;

namespace Graph3D.Vrml.Tokenizer {
    public class TokenizerContext {

        private readonly TokenizerSource _source;
        private readonly Vrml97Tokenizer _tokenizer;

        [DebuggerStepThrough]
        public TokenizerContext(string content, Vrml97Tokenizer tokenizer) {
            _source = new TokenizerSource(content);
            _tokenizer = tokenizer;
        }

        public Vrml97Tokenizer Tokenizer {
            [DebuggerStepThrough]
            get { return _tokenizer; }
        }

        public TokenizerSource Source {
            [DebuggerStepThrough]
            get { return _source; }
        }

        private readonly TokenQueue tokens = new();

        [DebuggerStepThrough]
        public void Enqueue(VRML97Token token) {
            tokens.Enqueue(token);
        }

        [DebuggerStepThrough]
        public VRML97Token Dequeue() {
            return tokens.Dequeue();
        }

        public int TokensCount {
            [DebuggerStepThrough]
            get { return tokens.Count; }
        }

        [DebuggerStepThrough]
        public char PeekChar() {
            return _source.PeekChar();
        }

        [DebuggerStepThrough]
        public char PeekChar(int distance) {
            return _source.PeekChar(distance);
        }

        private string state = "";

        private TokenizerPosition _position;
        public TokenizerPosition Position => _position;

        public void RequireChar(char ch) {
            var actual = ReadChar();
            if (actual != ch) {
                throw new InvalidVRMLSyntaxException($"Expected {ch} character", Position);
            }
        }

        public char ReadAndPeek() {
            ReadChar();
            return PeekChar();
        }
        
        //[DebuggerStepThrough]
        public char ReadChar() {
            var ch = _source.ReadChar();
            switch (state) {
                case "":
                    switch (ch) {
                        case '\r':
                            state = "r";
                            break;
                        case '\n':
                            _position.LineIndex++;
                            _position.ColumnIndex = 1;
                            break;
                        default:
                            _position.ColumnIndex++;
                            break;
                    }
                    break;
                case "r":
                    if (ch == '\n') {
                        _position.LineIndex++;
                        _position.ColumnIndex = 1;
                    }
                    state = "";
                    break;
            }
            return ch;
        }
    }
}
