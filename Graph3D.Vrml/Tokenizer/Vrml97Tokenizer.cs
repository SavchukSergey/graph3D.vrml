using System;
using System.IO;

namespace Graph3D.Vrml.Tokenizer {
    public partial class Vrml97Tokenizer {

        private readonly TokenizerContext context;

        public Vrml97Tokenizer(string content) {
            context = new TokenizerContext(content, this);
        }

        public Vrml97Tokenizer(TextReader reader) {
            var content = reader.ReadToEnd();
            context = new TokenizerContext(content, this);
        }

        public Vrml97Tokenizer(Stream stream)
            : this(new StreamReader(stream)) {
        }

        public VRML97Token ReadNextToken() {
            while (context.TokensCount == 0) {
                Tick();
            }
            return context.Dequeue();
        }

        private void Tick() {
            var ch = context.PeekChar();
            if (IsWhiteSpace(ch)) {
                context.ReadChar();
                return;
            }
            if (IsEOF(ch)) {
                context.Enqueue(new VRML97Token("".AsMemory(), VRML97TokenType.EOF));
                return;
            }
            if (IsLineComment(ch)) {
                ConsumeLineCommentToken();
                return;
            }
            if (IsPunctuation(ch)) {
                context.Enqueue(ConsumePunctuationToken());
                return;
            }
            if (IsQuote(ch)) {
                context.Enqueue(context.Source.ConsumeStringConstantToken());
                return;
            }
            if (IsIdFirstChar(ch)) {
                context.Enqueue(ConsumeWordToken());
                ch = context.PeekChar();

                while (IsMultipartIdentifierSeparator(ch)) {
                    context.ReadChar();
                    context.Enqueue(new VRML97Token(".".AsMemory(), VRML97TokenType.MutipartIdentifierSeparator));
                    context.Enqueue(ConsumeWordToken());
                    ch = context.PeekChar();
                }

                return;
            }
            if (IsNumberFirstChar(ch)) {
                context.Enqueue(ConsumeNumberToken());
                return;
            }
            throw new InvalidVRMLSyntaxException("Unexpected symbol", Position);
        }        

        public TokenPosition Position => context.Position;

        public static bool IsEOF(char ch) {
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

        public static bool IsLineComment(char ch) {
            return ch == '#';
        }

        public static bool IsQuote(char ch) {
            return ch == '"';
        }

        public static bool IsEscapeSymbol(char ch) {
            return ch == '\\';
        }

        public static bool IsIdFirstChar(char ch) {
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

        public static bool IsIdRestChar(char ch) {
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

        public static bool IsNumberFirstChar(char ch) {
            if (ch >= 0x30 && ch <= 0x39) return true;
            if (ch == '-') return true;
            if (ch == '+') return true;
            if (ch == '.') return true;
            return false;
        }


        public static bool IsPunctuation(char ch) {
            if (IsOpenBrace(ch)) return true;
            if (IsCloseBrace(ch)) return true;
            if (IsOpenBracket(ch)) return true;
            if (IsCloseBracket(ch)) return true;
            if (ch == ',') return true;
            return false;
        }

        public static bool IsOpenBrace(char ch) {
            return ch == '{';
        }

        public static bool IsCloseBrace(char ch) {
            return ch == '}';
        }

        public static bool IsOpenBracket(char ch) {
            return ch == '[';
        }

        public static bool IsCloseBracket(char ch) {
            return ch == ']';
        }

        public static bool IsMultipartIdentifierSeparator(char ch) {
            return ch == '.';
        }
    }
}
