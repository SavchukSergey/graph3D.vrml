using System.Diagnostics;

namespace Graph3D.Vrml.Tokenizer {
    public class TokensSource {

        public string Content { get; }

        public int Index { get; private set; }

        private TokenPosition _position;
        public TokenPosition Position => _position;

        public TokensSource(string content) {
            Content = content;
        }

        [DebuggerStepThrough]
        public char PeekChar() {
            return Index < Content.Length ? Content[Index] : (char)0xffff;
        }

        [DebuggerStepThrough]
        public char PeekChar(int distance) {
            return (Index + distance) < Content.Length ? Content[Index + distance] : (char)0xffff;
        }

        private char _state = '\0';

        [DebuggerStepThrough]
        public char ReadChar() {

            if (Index >= Content.Length) {
                return (char)0xffff;
            }

            var ch = Content[Index++];

            if (_state == '\0' && ch == '\n') {
                _position.LineIndex++;
                _position.ColumnIndex = 0;
            } else if (_state == '\r' && ch == '\n') {
                _position.LineIndex++;
                _position.ColumnIndex = 0;
                _state = '\0';
            } else {
                _position.ColumnIndex++;
                _state = '\0';
            }

            return ch;
        }

        public bool IsEOF => Index >= Content.Length;

    }
}