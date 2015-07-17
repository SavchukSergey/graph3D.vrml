using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Graph3D.Vrml.Tokenizer {
    public class TokenizerContext : IDisposable {

        private readonly TextReader reader;

        [DebuggerStepThrough]
        public TokenizerContext(TextReader reader, Vrml97Tokenizer tokenizer) {
            this.reader = reader;
            this.tokenizer = tokenizer;
        }

        private readonly Vrml97Tokenizer tokenizer;
        public Vrml97Tokenizer Tokenizer {
            [DebuggerStepThrough]
            get { return tokenizer; }
        }

        private readonly Queue<VRML97Token> tokens = new Queue<VRML97Token>();

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
            return (char)reader.Peek();
        }

        private string state = "";
        
        private int lineIndex = 1;
        public int LineIndex {
            get { return lineIndex; }
        }
        private int columnIndex = 1;
        public int ColumnIndex {
            get { return columnIndex; }
        }

        public string ReadLine() {
            string line = reader.ReadLine();
            lineIndex++;
            columnIndex = 1;
            return line;
        }

        //[DebuggerStepThrough]
        public char ReadChar() {
            char ch = (char)reader.Read();
            switch (state) {
                case "":
                    switch (ch) {
                        case '\r':
                            state = "r";
                            break;
                        case '\n':
                            lineIndex++;
                            columnIndex = 1;
                            break;
                        default:
                            columnIndex++;
                            break;
                    }
                    break;
                case "r":
                    if (ch == '\n') {
                        lineIndex++;
                        columnIndex = 1;
                    }
                    state = "";
                    break;
            }
            return ch;
        }

        #region IDisposable Members

        public void Dispose() {
            reader.Dispose();
        }

        #endregion
    }
}
