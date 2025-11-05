using System.Diagnostics;

namespace Graph3D.Vrml.Tokenizer {
    public class TokenizerContext {

        private readonly TokensSource _source;
        private readonly Vrml97Tokenizer _tokenizer;

        [DebuggerStepThrough]
        public TokenizerContext(string content, Vrml97Tokenizer tokenizer) {
            _source = new TokensSource(content);
            _tokenizer = tokenizer;
        }

        public Vrml97Tokenizer Tokenizer {
            [DebuggerStepThrough]
            get { return _tokenizer; }
        }

        public TokensSource Source {
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

        public TokenPosition Position => _source.Position;

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
            return _source.ReadChar();
        }
    }
}
