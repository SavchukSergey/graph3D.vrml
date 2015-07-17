using System;
using System.IO;

namespace Graph3D.Vrml.Tokenizer {
    public class Vrml97Tokenizer : IDisposable {

        private string header;
        private readonly TokenizerContext context;
        private VrmlTokenizerState currentState;

        public Vrml97Tokenizer(TextReader reader) {
            context = new TokenizerContext(reader, this);
            currentState = new InitialState(context);
        }

        public Vrml97Tokenizer(Stream stream)
            : this(new StreamReader(stream)) {
        }

        public VRML97Token ReadNextToken() {
            while (context.TokensCount == 0) {
                currentState = currentState.Tick();
            }
            return context.Dequeue();
        }

        public int LineIndex {
            get { return context.LineIndex; }
        }

        public int ColumnIndex {
            get { return context.ColumnIndex; }
        }

        public virtual bool IsEOF(char ch) {
            if (ch == 0xffff) return true;
            return false;
        }

        public virtual bool IsWhiteSpace(char ch) {
            if (ch == 0x0d) return true;
            if (ch == 0x0a) return true;
            if (ch == 0x20) return true;
            if (ch == 0x09) return true;
            if (ch == 0x2c) return true;
            return false;
        }

        public virtual bool IsLineComment(char ch) {
            return ch == '#';
        }

        public virtual bool IsQuote(char ch) {
            return ch == '"';
        }

        public virtual bool IsEscapeSymbol(char ch) {
            return ch == '\\';
        }

        public bool IsIdFirstChar(char ch) {
            if (ch >= 0x0 && ch <= 0x20) return false;
            if (ch == 0x27) return false;
            if (ch == 0x7f) return false;
            if (IsEOF(ch)) return false;
            if (IsQuote(ch)) return false;
            if (IsLineComment(ch)) return false;
            if (IsPunctuation(ch)) return false;
            if (IsEscapeSymbol(ch)) return false;
            if (IsNumberFirstChar(ch)) return false;
            return true;
        }

        public bool IsIdRestChar(char ch) {
            if (ch >= 0x0 && ch <= 0x20) return false;
            if (ch == 0x27) return false;
            if (ch == 0x2b) return false;
            if (ch == 0x2e) return false;
            if (ch == 0x7f) return false;
            if (IsEOF(ch)) return false;
            if (IsPunctuation(ch)) return false;
            if (IsEscapeSymbol(ch)) return false;
            return true;
        }

        public bool IsNumberFirstChar(char ch) {
            if (ch >= 0x30 && ch <= 0x39) return true;
            if (ch == '-') return true;
            if (ch == '+') return true;
            if (ch == '.') return true;
            return false;
        }


        public virtual bool IsPunctuation(char ch) {
            if (IsOpenBrace(ch)) return true;
            if (IsCloseBrace(ch)) return true;
            if (IsOpenBracket(ch)) return true;
            if (IsCloseBracket(ch)) return true;
            if (ch == ',') return true;
            return false;
        }

        #region IDisposable Members

        public void Dispose() {
            context.Dispose();
        }

        ~Vrml97Tokenizer() {
            Dispose();
        }

        #endregion

        public bool IsOpenBrace(char ch) {
            return ch == '{';
        }

        public bool IsCloseBrace(char ch) {
            return ch == '}';
        }

        public bool IsOpenBracket(char ch) {
            return ch == '[';
        }

        public bool IsCloseBracket(char ch) {
            return ch == ']';
        }

        public bool IsMultipartIdentifierSeparator(char ch) {
            return ch == '.';
        }
    }
}
