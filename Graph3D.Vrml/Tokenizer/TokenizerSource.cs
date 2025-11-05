using System.Diagnostics;

namespace Graph3D.Vrml.Tokenizer {
    public class TokenizerSource {

        public string Content { get; }

        public int Index { get; private set; }

        public TokenizerSource(string content) {
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


        [DebuggerStepThrough]
        public char ReadChar() {
            return Index < Content.Length ? Content[Index++] : (char)0xffff;
        }

        public bool IsEOF => Index >= Content.Length;

    }
}